
# Create a Project
dotnet new --help

dotnet new classlib -o DemoApp.Migration

# For migration development
dotnet add package FluentMigrator

# For migration execution
FluentMigrator.Runner 

# For db support
FluentMigrator.Runner.Postgres

# For ADO.NET for postgres
npgsql

*[x] 1. create a service provider to create a service for fluent migrator
*[x] 2. create a scoped service for the service provider collection
*[x] 3. run the fluent migrator


# Create a webapi project
 dotnet new webapi -o MyApp.API

	Add reference to main api project
  dotnet add reference ..\MyApp.Migration\MyApp.Migration.csproj


  # Git Commands  
  git init
  git status 
  git add .
  git commit -m "initial create"

