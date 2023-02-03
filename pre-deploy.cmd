dotnet restore

dotnet build TauCode.Xml.sln -c Debug
dotnet build TauCode.Xml.sln -c Release

dotnet test TauCode.Xml.sln -c Debug
dotnet test TauCode.Xml.sln -c Release

nuget pack nuget\TauCode.Xml.nuspec