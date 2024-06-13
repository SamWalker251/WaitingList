using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using FromBodyAttribute = Microsoft.Azure.Functions.Worker.Http.FromBodyAttribute;
namespace WaitingListFunctions
{
    public class Function1
    {
        private readonly ILogger<Function1> _logger;
        private readonly ProspectContext _context;
        public Function1(ILogger<Function1> logger, ProspectContext context)
        {
            _logger = logger;
            _context = context;
        }

        [Function("Prospect")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "post")] [FromBody] HttpProspect bodyProspect)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var prospect = new Prospect
            {
                FirstName = bodyProspect.FirstName,
                LastName = bodyProspect.LastName,
                Email = bodyProspect.Email,
                PhoneNumber = bodyProspect.PhoneNumber
            };

            _context.Prospects.Add(prospect);
            await _context.SaveChangesAsync();
            return new OkObjectResult(prospect);
        }

        [Function("GetProspects")]
        public async Task<IActionResult> GetProspects([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequest req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var prospects = await _context.Prospects.ToListAsync();
            return new OkObjectResult(prospects);
        }
    }


    public class HttpProspect
    {
        public string FirstName { get; set; } 
        public string LastName { get; set; } 
        public string Email { get; set; } 
        public string PhoneNumber { get; set; }
        public DateOnly? StartDate { get; set; }
        public string? Notes { get; set; }
        public string Postcode { get; set; }
        public bool IsDeleted { get; set; }
        public bool SpecificStartDate { get; set; }
        public bool IsConfirmed { get; set; }
    }

    public class Prospect
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string PhoneNumber { get; set; } = String.Empty;
        public DateOnly? StartDate { get; set; }
        public string? Notes { get; set; } = String.Empty;
        public string Postcode { get; set; } = String.Empty;
        public bool IsDeleted { get; set; }
        public bool SpecificStartDate { get; set; }
        public bool IsConfirmed { get; set; }
    }

    public class ProspectContext : DbContext
    {
        public DbSet<Prospect> Prospects { get; set; }

        public ProspectContext(DbContextOptions<ProspectContext> options) : base(options)
        {
        }
    }
}
