using NUnit.Framework;
using TauCode.Extensions;
using TauCode.Xml.Lab.Tests.NetCoreCsProj;
using TauCode.Xml.Lab.Tests.NetFrameworkCsProj;
using TauCode.Xml.Lab.Tests.Nuspec;

namespace TauCode.Xml.Lab.Tests
{
    [TestFixture]
    public class SerializerTests
    {
        private void TodoCompare(string actual, string expected, string extension = "sql")
        {
            TestHelper.WriteDiff(actual, expected, @"c:\temp\0-sql\", extension, "todo");
        }

        [Test]
        public void Deserialize_Nuspec_DeserializesCorrectly()
        {
            // Arrange
            var document = this.GetType().Assembly.GetResourceXml("TauCode.WebApi.Server.NHibernate.Nuspec.xml", true);
            var documentXml = this.GetType().Assembly.GetResourceText("TauCode.WebApi.Server.NHibernate.Nuspec.xml", true);
            var serializer = new Serializer();

            // Act
            var root = serializer.Deserialize(NuspecSchemaHolder.Schema, document);

            // Assert
            var serializedDocument = serializer.Serialize(root);
            var serializedDocumentXml = serializedDocument.ToXmlString();

            TodoCompare(serializedDocumentXml, documentXml, "xml");

            Assert.That(serializedDocumentXml, Is.EqualTo(documentXml));
        }

        [Test]
        public void Deserialize_NetFrameworkCsProj_DeserializesCorrectly()
        {
            // Arrange
            var document = this.GetType().Assembly.GetResourceXml("Elka.SBP.WebApi.CsProj.xml", true);
            var documentXml = this.GetType().Assembly.GetResourceText("Elka.SBP.WebApi.CsProj.xml", true);
            var serializer = new Serializer();

            // Act
            var root = serializer.Deserialize(NetFrameworkCsProjSchemaHolder.Schema, document);

            // Assert
            var serializedDocument = serializer.Serialize(root);
            var serializedDocumentXml = serializedDocument.ToXmlString();

            TodoCompare(serializedDocumentXml, documentXml, "xml");

            Assert.That(serializedDocumentXml, Is.EqualTo(documentXml));
        }

        [Test]
        public void Deserialize_NetCoreCsProj_DeserializesCorrectly()
        {
            // Arrange
            var document = this.GetType().Assembly.GetResourceXml("IntegrationTests.CsProj.xml", true);
            var documentXml = this.GetType().Assembly.GetResourceText("IntegrationTests.CsProj.xml", true);
            var serializer = new Serializer();

            // Act
            var root = serializer.Deserialize(NetCoreCsProjSchemaHolder.Schema, document);

            // Assert
            var serializedDocument = serializer.Serialize(root);
            var serializedDocumentXml = serializedDocument.ToXmlString();

            TodoCompare(serializedDocumentXml, documentXml, "xml");

            Assert.That(serializedDocumentXml, Is.EqualTo(documentXml));
        }

    }
}
