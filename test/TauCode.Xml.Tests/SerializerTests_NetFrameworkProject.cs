using NUnit.Framework;
using TauCode.Extensions;
using TauCode.Xml.Tests.NetFrameworkCsProj;

namespace TauCode.Xml.Tests
{
    [TestFixture]
    public partial class SerializerTests
    {
        [Test]
        public void Serialize_NetFrameworkCsProj_SerializesCorrectly()
        {
            // Arrange
            var serializer = new Serializer();
            var xml = this.GetType().Assembly.GetResourceXml("Elka.SBP.WebApi.CsProj.xml", true);
            var xmlString = this.GetType().Assembly.GetResourceText("Elka.SBP.WebApi.CsProj.xml", true);

            var builder = new SchemaBuilder();
            var schemaDescriptor = builder.Build(typeof(Project), "Project");

            // Act
            var package = serializer.Deserialize<Project>(schemaDescriptor, xml.DocumentElement);
            var serializedPackageXml = serializer.Serialize(schemaDescriptor, package);
            var serializedPackageXmlString = serializedPackageXml.ToXmlString();

            // Assert
            if (xmlString != serializedPackageXmlString)
            {
                TodoCompare(serializedPackageXmlString, xmlString, "xml");
            }

            Assert.That(serializedPackageXmlString, Is.EqualTo(xmlString));
        }

    }
}
