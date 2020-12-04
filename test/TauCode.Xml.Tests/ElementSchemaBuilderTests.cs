using System;
using NUnit.Framework;
using TauCode.Xml.Tests.Nuspec;

namespace TauCode.Xml.Tests
{
    [TestFixture]
    public class ElementSchemaBuilderTests
    {
        [Test]
        public void Build_ValidInput_BuildsSchema()
        {
            // Arrange

            // Act
            var schema = NuspecSchemaHolder.Build();

            // Assert
            throw new NotImplementedException("go on!");
        }
    }
}
