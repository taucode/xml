using NUnit.Framework;
using System;
using System.Globalization;
using TauCode.Extensions;
using TauCode.Xml.Tests.Nuspec;

namespace TauCode.Xml.Tests
{
    [TestFixture]
    public class XmlDataSerializerTests
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            Inflector.Inflector.SetDefaultCultureFunc = () => new CultureInfo("en-US");
        }

        [Test]
        public void TodoFoo()
        {
            // Arrange
            var serializer = new XmlDataSerializer();
            var xml = this.GetType().Assembly.GetResourceXml("TauCode.WebApi.Server.NHibernate.Nuspec.xml", true);

            // Act
            var package = serializer.Deserialize<Package>(xml.DocumentElement);


            // Assert
            var props = typeof(Metadata).GetProperties();

            throw new NotImplementedException("go on!");
        }
    }
}
