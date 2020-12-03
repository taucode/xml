using NUnit.Framework;
using System;
using TauCode.Xml.Lab.Tests.Nuspec;

namespace TauCode.Xml.Lab.Tests
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
