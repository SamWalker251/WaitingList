## Pre-requisites
docker desktop installed
.net 8 sdk installed

Probably want Sql Server Management Studio (ssms) or Azure Data Studio to view the database (I recommend data studio because it is less cumbersome)

## Running the function app locally
To spin up your db, open a terminal in waiting list function directory (waiting-list\Backend\WaitingListFunctions)
and run the following command: ```docker-compose up --build```

This will start a docker container with a Sql Server instance running on it. 
The database will be created with the tables from the Scripts folder of the WaitingListTestDb project.

Within the local settings of the function app, you will need to add a connection string to the database. In the Values section, add the following:

"dbConnection": "Server=tcp:localhost,1533;Database=ProspectsDb;Persist Security Info=False;User ID=sa;Password=Password123;MultipleActiveResultSets=False;Connection Timeout=5;TrustServerCertificate=true;"

This will allow the function app to connect to the database.

Now you should be able to run the function app locally. When you call the Get Prospects function, it will return the data from the database.

If you want to dispose of the database you can run the following command in the terminal: ```docker-compose down``` This will stop the container and remove it.