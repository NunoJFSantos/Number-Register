# Number-Register
ASP.Net Core web application developed for a job tech challenge

# The Project
Web application implementing CRUD operations on number registrations. Also displays an interface for the insertion of persisted data id's and retrieving the sum of this data's values.

# Instructions
Before running the application edit your database server settings on the NumberRegister/appsettings.json file, replacing the text in single quotes as follows:

```
"ConnectionStrings": {
    "DefaultConnection": "Server='serverName';Database=NumberRegister; User='userName'; Password='password'; MultipleActiveResultSets=True"
  }
  ```

To run the application, first ```cd``` to: 

```cd NumberRegister/bin/Release/netcoreapp3.1/win-x64/```

Then run the following commands to install the required packages, run database migrations, and start the application:

```
dotnet tool install -g dotnet-ef
dotnet ef database update
dotnet run NumberRegister.exe
```

Finally navigate to https://localhost:5001/NumberRegister in your browser.

### MacOS:

```
cd NumberRegister/bin/Release/netcoreapp3.1/osx-x64/
dotnet tool install -g dotnet-ef
dotnet ef database update
dotnet run NumberRegister
```
