using NUnit.Framework;
using System.Globalization;
using TauCode.Extensions;
using TauCode.Xml.Omicron.Tests.Nuspec;

namespace TauCode.Xml.Omicron.Tests
{
    [TestFixture]
    public class TodoSerializerTests
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Inflector.Inflector.SetDefaultCultureFunc = () => new CultureInfo("en-US");
        }

        [Test]
        public void TodoFooSerialize()
        {
            // Arrange
            var serializer = new Serializer();
            var xml = this.GetType().Assembly.GetResourceXml("TauCode.WebApi.Server.NHibernate.Nuspec.xml", true);

            var builder = new SchemaBuilder();
            var schemaDescriptor = builder.Build(typeof(Package));

            // Act
            var package = serializer.Deserialize<Package>(schemaDescriptor, xml.DocumentElement);

            // Assert
        }
    }
}
