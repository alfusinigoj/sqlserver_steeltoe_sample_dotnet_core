echo "dotnet restore"
dotnet restore

echo "dotnet build.. building the application"
dotnet build SqlServer.Steeltoe.Sample.Core.csproj
