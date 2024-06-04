using DbUp;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Reflection;
using Microsoft.Data.SqlClient;
using Polly;

var builder = new ConfigurationBuilder()
    .AddJsonFile($"testsettings.json", optional: false)
    .AddEnvironmentVariables();
var connectionString = builder.Build().GetValue<string>("ProspectsDbConnectionString");

var retryCount = 5;
var deployDatabaseRetryPolicy = Policy
    .Handle<SqlException>()
    .WaitAndRetry(retryCount,
        _ => TimeSpan.FromSeconds(10),
        (ex, wait, attemptCount, _) =>
        {
            Console.WriteLine($"Failed deploying database. Waiting {wait}. Attempt {attemptCount}/{retryCount}. Exception: {ex}");
        });

var result = deployDatabaseRetryPolicy.Execute(() =>
{
    SqlConnectionStringBuilder connectionStringBuilder = new(connectionString);
    var catalog = connectionStringBuilder.InitialCatalog;
    DropDatabase.For.SqlDatabase(connectionString);
    EnsureDatabase.For.SqlDatabase(connectionString);

    var upgrader = DeployChanges.To
        .SqlDatabase(connectionString)
        .WithVariable("DatabaseName", catalog)
        .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
        .LogToConsole()
        .Build();
    return upgrader.PerformUpgrade();
});

if (!result.Successful)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(result.Error);
    Console.ResetColor();
#if DEBUG
    Console.ReadLine();
#endif
    return -1;
}

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("Success!");
Console.ResetColor();
return 0;
