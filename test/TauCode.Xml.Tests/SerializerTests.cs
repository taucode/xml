using NUnit.Framework;
using TauCode.Extensions;

namespace TauCode.Xml.Tests;

[TestFixture]
public class SerializerTests
{
    [Test]
    public void Deserialize_ValidArgument_DeserializesCorrectly()
    {
        // Arrange
        var serializer = new Serializer();
        var xmlDoc = this.GetType().Assembly.GetResourceXml(".Nuget.nuspec", true);

        // Act
        var packageNuspec = serializer.Deserialize<PackageNuspec>(xmlDoc);

        // Assert

        // metadata
        Assert.That(packageNuspec.metadata, Is.Not.Null);
        Assert.That(packageNuspec.metadata.id, Is.EqualTo("TauCode.WebApi.Testing"));
        Assert.That(packageNuspec.metadata.version, Is.EqualTo("1.3.8-alpha.1.2022-07-28.09-02"));
        Assert.That(packageNuspec.metadata.authors, Is.EqualTo("TauCode"));
        Assert.That(packageNuspec.metadata.authors, Is.EqualTo("TauCode"));
        Assert.That(packageNuspec.metadata.requireLicenseAcceptance, Is.EqualTo(false));

        Assert.That(packageNuspec.metadata.license.type, Is.EqualTo("file"));
        Assert.That(packageNuspec.metadata.license.FileName, Is.EqualTo("LICENSE"));

        Assert.That(packageNuspec.metadata.projectUrl, Is.EqualTo("https://github.com/taucode/taucode.webapi.testing"));

        Assert.That(packageNuspec.metadata.repository.type, Is.EqualTo("git"));
        Assert.That(packageNuspec.metadata.repository.url, Is.EqualTo("https://github.com/taucode/taucode.webapi.testing"));

        Assert.That(packageNuspec.metadata.description.Trim(), Is.EqualTo("TauCode Web API apps testing support"));
        Assert.That(packageNuspec.metadata.releaseNotes.Trim(), Is.EqualTo("Developing release 1.3.8."));
        Assert.That(packageNuspec.metadata.tags, Is.EqualTo("taucode web api unit integration testing"));

        Assert.That(packageNuspec.metadata.dependencies.Groups, Has.Count.EqualTo(1));

        var dependency = packageNuspec.metadata.dependencies.Groups[0].Dependencies[0];
        Assert.That(dependency.id, Is.EqualTo("NHibernate"));
        Assert.That(dependency.version, Is.EqualTo("5.3.12"));

        dependency = packageNuspec.metadata.dependencies.Groups[0].Dependencies[1];
        Assert.That(dependency.id, Is.EqualTo("NUnit"));
        Assert.That(dependency.version, Is.EqualTo("3.13.3"));

        dependency = packageNuspec.metadata.dependencies.Groups[0].Dependencies[2];
        Assert.That(dependency.id, Is.EqualTo("TauCode.Db.Testing"));
        Assert.That(dependency.version, Is.EqualTo("1.3.7"));

        dependency = packageNuspec.metadata.dependencies.Groups[0].Dependencies[3];
        Assert.That(dependency.id, Is.EqualTo("TauCode.WebApi.Client"));
        Assert.That(dependency.version, Is.EqualTo("1.3.7"));

        dependency = packageNuspec.metadata.dependencies.Groups[0].Dependencies[4];
        Assert.That(dependency.id, Is.EqualTo("TauCode.WebApi.Server"));
        Assert.That(dependency.version, Is.EqualTo("1.3.7"));

        // files
        Assert.That(packageNuspec.files.files[0].src, Is.EqualTo(@"..\LICENSE*"));
        Assert.That(packageNuspec.files.files[0].target, Is.EqualTo(@""));

        Assert.That(packageNuspec.files.files[1].src, Is.EqualTo(@"..\src\TauCode.WebApi.Testing\bin\Release\netstandard2.1\TauCode.WebApi.Testing.dll"));
        Assert.That(packageNuspec.files.files[1].target, Is.EqualTo(@"lib\netstandard2.1"));

        Assert.That(packageNuspec.files.files[2].src, Is.EqualTo(@"..\src\TauCode.WebApi.Testing\bin\Release\netstandard2.1\TauCode.WebApi.Testing.pdb"));
        Assert.That(packageNuspec.files.files[2].target, Is.EqualTo(@"lib\netstandard2.1"));
    }
}