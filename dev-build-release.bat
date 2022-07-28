dotnet restore

dotnet build --configuration Debug
dotnet build --configuration Release

dotnet test -c Debug .\test\TauCode.Xml.Tests\TauCode.Xml.Tests.csproj
dotnet test -c Release .\test\TauCode.Xml.Tests\TauCode.Xml.Tests.csproj

nuget pack nuget\TauCode.Xml.nuspec