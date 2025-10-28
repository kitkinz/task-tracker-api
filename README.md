# Task Tracker API
A RESTful API built with ASP.NET Core and EF Core for managing tasks. It connects to an Amazon Aurora PostgreSQL <br />
database hosted on AWS RDS and follows clean architecture and async programming best practices.

## Tech Stack
* ASP.NET Core Web API for backend logic
* Entity Framework Core for data access
* Amazon Aurora PostgreSQL on AWS RDS for persistent storage
* Git for version control

## Usage
1. Clone this repository:
```
git clone https://github.com/kitkinz/task-tracker-api.git
```
2. Navigate to the project directory:
```
cd TaskTrackerAPI
```
3. Restore dependencies:
```
dotnet restore
```
4. Configure your database connection. Go to `appsettings.test.json`, replace the values then rename the file to 
`appsettings.json`:
```
{
  "DbConnectionString": "Server=localhost;Port=5432;Database=database;User ID=username;Password=password"
}
```
*This project uses PostgreSQL as the database. You’re free to use any SQL database server of your choice, 
just make sure to install the corresponding NuGet packages and update the configuration settings as needed.*
5. Build then run the project:
```
dotnet build
dotnet run
```
6. Access the API documentation and test it by going to `localhost:port/docs`.
