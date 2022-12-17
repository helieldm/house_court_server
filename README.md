# House court API

## Requirements

In order for the API to run with db properly, you will need the following tools :
- https://dotnet.microsoft.com/en-us/download -> Choose .net 6
- https://www.postgresql.org/download/ -> Any stable version

## First migration

    dotnet tool install --global dotnet-ef
    dotnet tool update --global dotnet-ef
    dotnet ef database update

Don't forget to replace the connection string with your own credentials and db name in the HouseCourtContext.cs file (you need to create a db using pgadmin)
