using System.Globalization;
using System.Linq;
using NUnit.Framework;
using TauCode.Extensions;
using TauCode.Xml.Tests.SampleSchemas;

namespace TauCode.Xml.Tests
{
    [TestFixture]
    public class SerializerTests
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Inflector.Inflector.SetDefaultCultureFunc = () => new CultureInfo("en-US");
        }

        [Test]
        public void DeserializeXmlElement_AllBoundProperties_DeserializesCorrectly()
        {
            // Arrange
            var doc = this.GetType().Assembly.GetResourceXml("Person1.xml", true);
            var serializer = new Serializer();

            // Act
            var vito = serializer.DeserializeXmlElement<BoundPerson>(doc.DocumentElement);

            // Assert
            Assert.That(vito.Name, Is.EqualTo("Vito Corleone"));
            Assert.That(vito.Age, Is.EqualTo(63));
            Assert.That(vito.Gender, Is.EqualTo(Gender.Male));

            var carmela = vito.Spouse;
            Assert.That(carmela, Is.Not.Null);
            Assert.That(carmela.Name, Is.EqualTo("Carmela"));
            Assert.That(carmela.Age, Is.EqualTo(60));
            Assert.That(carmela.Gender, Is.EqualTo(Gender.Female));

            var kid = vito.Kids[0];
            Assert.That(kid.Name, Is.EqualTo("Sonny"));
            Assert.That(kid.Age, Is.EqualTo(35));
            Assert.That(kid.Gender, Is.EqualTo(Gender.Male));

            kid = vito.Kids[1];
            Assert.That(kid.Name, Is.EqualTo("Freddie"));
            Assert.That(kid.Age, Is.EqualTo(31));
            Assert.That(kid.Gender, Is.EqualTo(Gender.Male));

            kid = vito.Kids[2];
            Assert.That(kid.Name, Is.EqualTo("Connie"));
            Assert.That(kid.Age, Is.EqualTo(24));
            Assert.That(kid.Gender, Is.EqualTo(Gender.Female));

            kid = vito.Kids[3];
            Assert.That(kid.Name, Is.EqualTo("Michael"));
            Assert.That(kid.Age, Is.EqualTo(21));
            Assert.That(kid.Gender, Is.EqualTo(Gender.Male));
        }

        [Test]
        public void DeserializeXmlElement_Unbound_DeserializesCorrectly()
        {
            // Arrange
            var doc = this.GetType().Assembly.GetResourceXml("Person1.xml", true);
            var serializer = new Serializer();

            // Act
            var vito = serializer.DeserializeXmlElement<UnboundPerson>(doc.DocumentElement);

            // Assert
            Assert.That(vito.UnboundAttributes["Name"], Is.EqualTo("Vito Corleone"));
            Assert.That(vito.UnboundAttributes["Age"].ToInt32(), Is.EqualTo(63));
            Assert.That(vito.UnboundAttributes["Gender"].ToEnum<Gender>(), Is.EqualTo(Gender.Male));

            var carmela = vito.UnboundChildren.Cast<UnknownComplexElement>().Single(x => x.ElementName == "Spouse");
            Assert.That(carmela, Is.Not.Null);
            Assert.That(carmela.UnboundAttributes["Name"], Is.EqualTo("Carmela"));
            Assert.That(carmela.UnboundAttributes["Age"].ToInt32(), Is.EqualTo(60));
            Assert.That(carmela.UnboundAttributes["Gender"].ToEnum<Gender>(), Is.EqualTo(Gender.Female));

            var kids = vito
                .UnboundChildren
                .Cast<UnknownComplexElement>()
                .Where(x => x.ElementName == "Kid")
                .ToList();

            var kid = kids[0];
            Assert.That(kid.UnboundAttributes["Name"], Is.EqualTo("Sonny"));
            Assert.That(kid.UnboundAttributes["Age"].ToInt32(), Is.EqualTo(35));
            Assert.That(kid.UnboundAttributes["Gender"].ToEnum<Gender>(), Is.EqualTo(Gender.Male));

            kid = kids[1];
            Assert.That(kid.UnboundAttributes["Name"], Is.EqualTo("Freddie"));
            Assert.That(kid.UnboundAttributes["Age"].ToInt32(), Is.EqualTo(31));
            Assert.That(kid.UnboundAttributes["Gender"].ToEnum<Gender>(), Is.EqualTo(Gender.Male));

            kid = kids[2];
            Assert.That(kid.UnboundAttributes["Name"], Is.EqualTo("Connie"));
            Assert.That(kid.UnboundAttributes["Age"].ToInt32(), Is.EqualTo(24));
            Assert.That(kid.UnboundAttributes["Gender"].ToEnum<Gender>(), Is.EqualTo(Gender.Female));

            kid = kids[3];
            Assert.That(kid.UnboundAttributes["Name"], Is.EqualTo("Michael"));
            Assert.That(kid.UnboundAttributes["Age"].ToInt32(), Is.EqualTo(21));
            Assert.That(kid.UnboundAttributes["Gender"].ToEnum<Gender>(), Is.EqualTo(Gender.Male));
        }

        [Test]
        public void DeserializeXmlDocument_Nuspec_DeserializesCorrectly()
        {
            // Arrange
            var doc = this.GetType().Assembly.GetResourceXml("TauCode.WebApi.Testing.nuspec", true);
            var serializer = new Serializer();

            // Act
            var nuspec = serializer.DeserializeXmlDocument<Nuspec>(doc);

            // Assert
            Assert.That(nuspec.Xmlns, Is.EqualTo("http://schemas.microsoft.com/packaging/2013/05/nuspec.xsd"));
            Assert.That(nuspec.Declaration.ToString(), Is.EqualTo("<?xml version=\"1.0\" encoding=\"utf-8\" standalone=\"yes\"?>"));
            Assert.That(nuspec.RootElementName, Is.EqualTo("package"));

            var metadata = nuspec.Metadata;
            Assert.That(metadata.Id, Is.EqualTo("TauCode.WebApi.Testing"));
            Assert.That(metadata.Version, Is.EqualTo("1.3.2.7-dev-2021-04-23-09-29"));
            Assert.That(metadata.Authors, Is.EqualTo("TauCode"));
            Assert.That(metadata.Owners, Is.EqualTo("TauCode"));
            Assert.That(metadata.RequireLicenseAcceptance, Is.False);

            Assert.That(metadata.License.Type, Is.EqualTo("file"));
            Assert.That(metadata.License.Value, Is.EqualTo("LICENSE.txt"));

            Assert.That(metadata.ProjectUrl, Is.EqualTo("https://github.com/taucode/taucode.webapi.testing"));

            Assert.That(metadata.Repository.Type, Is.EqualTo("git"));
            Assert.That(metadata.Repository.Url, Is.EqualTo("https://github.com/taucode/taucode.webapi.testing"));

            Assert.That(metadata.Description.Trim(), Is.EqualTo("TauCode Web API apps testing support"));
            Assert.That(metadata.ReleaseNotes.Trim(), Is.EqualTo("Resurrection."));
            Assert.That(metadata.Tags, Is.EqualTo("taucode web api testing"));

            var group = metadata.Dependencies.Groups.Single();
            Assert.That(group.TargetFramework, Is.EqualTo(".NETStandard2.1"));

            var dependencies = group.Dependencies;
            Assert.That(dependencies, Has.Count.EqualTo(5));

            var dependency = dependencies[0];
            Assert.That(dependency.Id, Is.EqualTo("NHibernate"));
            Assert.That(dependency.Version, Is.EqualTo("5.3.8"));

            dependency = dependencies[1];
            Assert.That(dependency.Id, Is.EqualTo("NUnit"));
            Assert.That(dependency.Version, Is.EqualTo("3.13.1"));

            dependency = dependencies[2];
            Assert.That(dependency.Id, Is.EqualTo("TauCode.Db.Testing"));
            Assert.That(dependency.Version, Is.EqualTo("1.3.2.7-dev-2021-04-23-09-29"));

            dependency = dependencies[3];
            Assert.That(dependency.Id, Is.EqualTo("TauCode.WebApi.Client"));
            Assert.That(dependency.Version, Is.EqualTo("1.3.2.7-dev-2021-04-22-09-25"));

            dependency = dependencies[4];
            Assert.That(dependency.Id, Is.EqualTo("TauCode.WebApi.Server"));
            Assert.That(dependency.Version, Is.EqualTo("1.3.2.7-dev-2021-04-22-21-47"));

            var files = nuspec.Files.Files;
            Assert.That(files, Has.Count.EqualTo(3));

            var file = files[0];
            Assert.That(file.Src, Is.EqualTo(@"..\LICENSE.txt"));
            Assert.That(file.Target, Is.EqualTo(@""));

            file = files[1];
            Assert.That(file.Src, Is.EqualTo(@"..\src\TauCode.WebApi.Testing\bin\Release\netstandard2.1\TauCode.WebApi.Testing.dll"));
            Assert.That(file.Target, Is.EqualTo(@"lib\netstandard2.1"));

            file = files[2];
            Assert.That(file.Src, Is.EqualTo(@"..\src\TauCode.WebApi.Testing\bin\Release\netstandard2.1\TauCode.WebApi.Testing.pdb"));
            Assert.That(file.Target, Is.EqualTo(@"lib\netstandard2.1"));
        }

        [Test]
        public void SerializeDocument_Nuspec_SerializesCorrectly()
        {
            // Arrange
            var docString = this.GetType().Assembly.GetResourceText("TauCode.WebApi.Testing.nuspec", true);
            var doc = this.GetType().Assembly.GetResourceXml("TauCode.WebApi.Testing.nuspec", true);
            var serializer = new Serializer();
            serializer.Settings = SerializationSettings.CreateDefault();
            serializer.Settings.BoundPropertyValueConverter = new Nuspec.NuspecConverter();

            var nuspec = serializer.DeserializeXmlDocument<Nuspec>(doc);

            // Act
            var xmlDocument = serializer.SerializeDocument(nuspec);
            var xmlDocumentString = xmlDocument.ToXmlString();

            // Assert
            if (docString != xmlDocumentString)
            {
                TestHelper.WriteDiff(xmlDocumentString, docString, @"c:\temp\_del_asap-01", "xml", "todo");
            }

            Assert.That(docString, Is.EqualTo(xmlDocumentString));
        }
    }
}
