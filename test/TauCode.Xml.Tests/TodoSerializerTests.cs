using System.Globalization;
using System.Xml;
using NUnit.Framework;
using TauCode.Extensions;
using TauCode.Xml.Tests.Nuspec;

namespace TauCode.Xml.Tests
{
    [TestFixture]
    public class TodoSerializerTests
    {
        private void TodoCompare(string actual, string expected, string extension = "sql")
        {
            TestHelper.WriteDiff(actual, expected, @"c:\temp\0-sql\", extension, "todo");
        }

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Inflector.Inflector.SetDefaultCultureFunc = () => new CultureInfo("en-US");
        }

        [Test]
        public void TodoFooDeserialize()
        {
            // Arrange
            var serializer = new Serializer();
            var xml = this.GetType().Assembly.GetResourceXml("TauCode.WebApi.Server.NHibernate.Nuspec.xml", true);

            var builder = new SchemaBuilder();
            var schemaDescriptor = builder.Build(typeof(Package), "package");

            // Act
            var package = serializer.Deserialize<Package>(schemaDescriptor, xml.DocumentElement);

            // Assert
            // todo: assertions!
        }

        [Test]
        public void TodoFooSerialize()
        {
            // Arrange
            var serializer = new Serializer();
            var xml = this.GetType().Assembly.GetResourceXml("TauCode.WebApi.Server.NHibernate.Nuspec.xml", true);
            var xmlString = this.GetType().Assembly.GetResourceText("TauCode.WebApi.Server.NHibernate.Nuspec.xml", true);

            var builder = new SchemaBuilder();
            var schemaDescriptor = builder.Build(typeof(Package), "package");

            // Act
            var package = serializer.Deserialize<Package>(schemaDescriptor, xml.DocumentElement);
            var serializedPackageXml = serializer.Serialize(schemaDescriptor, package);
            var serializedPackageXmlString = serializedPackageXml.ToXmlString();

            // Assert
            if (xmlString != serializedPackageXmlString)
            {
                TodoCompare(serializedPackageXmlString, xmlString, "xml");

                XmlDeclaration de;
            }

            Assert.That(serializedPackageXmlString, Is.EqualTo(xmlString));
        }
    }
}
