## Sample .net core web api application demonstrating the use of sqlserver connection using steeltoe.

### Points to follow, in general to use steeltoe connector to connect sqlserver, configuration using VCAP (CUPS)
- Add below packages, latest versions preferred
```
    <PackageReference Include="Steeltoe.Extensions.Configuration.CloudFoundryCore" Version="2.0.1"/>
    <PackageReference Include="Steeltoe.Management.CloudFoundryCore" Version= "2.0.1"/>
    <PackageReference Include="Steeltoe.CloudFoundry.ConnectorCore" Version="2.0.0" />
```
- Add below extension method in Program.cs which pulls out VCAP configurations in IConfigurations
```IConfigurationBuilder.AddCloudFoundry()```

- Add below extension method in Startup.cs which pulls out VCAP configurations in IConfigurations
```services.AddSqlServerConnection(Configuration);```

- Push the application to PCF using the below command (if no manifest is available), else use just "cf push". Fill the place holders appropriately
```cf push <app_name> -b https://github.com/cloudfoundry/dotnet-core-buildpack.git --no-start```

- Create the VCAP service (User Provided Service), using the below command. Fill the place holders appropriately
```cf uups <service_name> -p '{"username”:”<sql_username>”,”password":"<sql_password>”,”uri”:"sqlserver://<server_hostname>:<port>","name":"<database_name>"}'```

- Bind the created service to the app using the below command
```cf bs <app_name> <service_name>```

- Start the application using the below command
```cf restart <app_name>```

### To run this application, follow the below steps

- Comment out the below line in Program.cs, as it is used only for demonstrating VCAP service usage from a developer machine (without PCF)
```.AddJsonFile($"vcap.services.json", optional: false, reloadOnChange: false)```

- Push the application to PCF using the below command, no arguments necessary as we have the manifest file
```cf push --no-start```

- Create the VCAP service (User Provided Service), using the below command. Fill the place holders appropriately
```cf uups <service_name> -p '{"username”:”<sql_username>”,”password":"<sql_password>”,”uri”:"sqlserver://<server_hostname>:<port>","name":"<database_name>"}'```

- Bind the created service to the app using the below command
```cf bs <app_name> <service_name>```

- Start the application using the below command
```cf restart <app_name>```
