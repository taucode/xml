using NUnit.Framework;
using System.Globalization;
using System.Linq;
using TauCode.Xml.Omicron.Descriptors;
using TauCode.Xml.Omicron.Tests.Nuspec;

namespace TauCode.Xml.Omicron.Tests
{
    [TestFixture]
    public class TodoFixture
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
            var builder = new SchemaBuilder();

            // Act
            var schemaDescriptor = builder.Build(typeof(Package));

            // Assert

            Assert.That(schemaDescriptor.Elements, Has.Count.EqualTo(8));

            #region package

            var elementDescriptor = schemaDescriptor.Elements[typeof(Package)];

            Assert.That(elementDescriptor.Type, Is.EqualTo(typeof(Package)));
            Assert.That(elementDescriptor.AttributeProperties, Is.Empty);
            Assert.That(elementDescriptor.InnerTextProperty, Is.Null);

            var elementProperties = elementDescriptor.ElementProperties;
            Assert.That(elementProperties, Has.Count.EqualTo(2));

            var elementProperty = elementProperties["metadata"];
            Assert.That(elementProperty.Kind, Is.EqualTo(ElementPropertyKind.ComplexElement));
            Assert.That(elementProperty.ElementName, Is.EqualTo("metadata"));
            Assert.That(
                elementProperty.Property,
                Is.SameAs(typeof(Package).GetProperties().Single(x => x.Name == "Metadata")));
            Assert.That(elementProperty.Element, Is.SameAs(schemaDescriptor.Elements[typeof(Metadata)]));

            elementProperty = elementProperties["files"];
            Assert.That(elementProperty.Kind, Is.EqualTo(ElementPropertyKind.ComplexElement));
            Assert.That(elementProperty.ElementName, Is.EqualTo("files"));
            Assert.That(
                elementProperty.Property,
                Is.SameAs(typeof(Package).GetProperties().Single(x => x.Name == "Files")));
            Assert.That(elementProperty.Element, Is.SameAs(schemaDescriptor.Elements[typeof(FilesElement)]));

            #endregion

            #region metadata

            elementDescriptor = schemaDescriptor.Elements[typeof(Metadata)];

            Assert.That(elementDescriptor.Type, Is.EqualTo(typeof(Metadata)));
            Assert.That(elementDescriptor.AttributeProperties, Is.Empty);
            Assert.That(elementDescriptor.InnerTextProperty, Is.Null);

            elementProperties = elementDescriptor.ElementProperties;
            Assert.That(elementProperties, Has.Count.EqualTo(11));

            // id
            elementProperty = elementProperties["id"];
            Assert.That(elementProperty.Kind, Is.EqualTo(ElementPropertyKind.ValueElement));
            Assert.That(elementProperty.ElementName, Is.EqualTo("id"));
            Assert.That(
                elementProperty.Property,
                Is.SameAs(typeof(Metadata).GetProperties().Single(x => x.Name == "Id")));
            Assert.That(elementProperty.Element, Is.Null);

            // version
            elementProperty = elementProperties["version"];
            Assert.That(elementProperty.Kind, Is.EqualTo(ElementPropertyKind.ValueElement));
            Assert.That(elementProperty.ElementName, Is.EqualTo("version"));
            Assert.That(
                elementProperty.Property,
                Is.SameAs(typeof(Metadata).GetProperties().Single(x => x.Name == "Version")));
            Assert.That(elementProperty.Element, Is.Null);

            // authors
            elementProperty = elementProperties["authors"];
            Assert.That(elementProperty.Kind, Is.EqualTo(ElementPropertyKind.ValueElement));
            Assert.That(elementProperty.ElementName, Is.EqualTo("authors"));
            Assert.That(
                elementProperty.Property,
                Is.SameAs(typeof(Metadata).GetProperties().Single(x => x.Name == "Authors")));
            Assert.That(elementProperty.Element, Is.Null);

            // owners
            elementProperty = elementProperties["owners"];
            Assert.That(elementProperty.Kind, Is.EqualTo(ElementPropertyKind.ValueElement));
            Assert.That(elementProperty.ElementName, Is.EqualTo("owners"));
            Assert.That(
                elementProperty.Property,
                Is.SameAs(typeof(Metadata).GetProperties().Single(x => x.Name == "Owners")));
            Assert.That(elementProperty.Element, Is.Null);

            // requireLicenseAcceptance
            elementProperty = elementProperties["requireLicenseAcceptance"];
            Assert.That(elementProperty.Kind, Is.EqualTo(ElementPropertyKind.ValueElement));
            Assert.That(elementProperty.ElementName, Is.EqualTo("requireLicenseAcceptance"));
            Assert.That(
                elementProperty.Property,
                Is.SameAs(typeof(Metadata).GetProperties().Single(x => x.Name == "RequireLicenseAcceptance")));
            Assert.That(elementProperty.Element, Is.Null);

            // license
            elementProperty = elementProperties["license"];
            Assert.That(elementProperty.Kind, Is.EqualTo(ElementPropertyKind.ComplexElement));
            Assert.That(elementProperty.ElementName, Is.EqualTo("license"));
            Assert.That(
                elementProperty.Property,
                Is.SameAs(typeof(Metadata).GetProperties().Single(x => x.Name == "License")));
            Assert.That(elementProperty.Element, Is.SameAs(schemaDescriptor.Elements[typeof(License)]));

            // projectUrl
            elementProperty = elementProperties["projectUrl"];
            Assert.That(elementProperty.Kind, Is.EqualTo(ElementPropertyKind.ValueElement));
            Assert.That(elementProperty.ElementName, Is.EqualTo("projectUrl"));
            Assert.That(
                elementProperty.Property,
                Is.SameAs(typeof(Metadata).GetProperties().Single(x => x.Name == "ProjectUrl")));
            Assert.That(elementProperty.Element, Is.Null);

            // description
            elementProperty = elementProperties["description"];
            Assert.That(elementProperty.Kind, Is.EqualTo(ElementPropertyKind.ValueElement));
            Assert.That(elementProperty.ElementName, Is.EqualTo("description"));
            Assert.That(
                elementProperty.Property,
                Is.SameAs(typeof(Metadata).GetProperties().Single(x => x.Name == "Description")));
            Assert.That(elementProperty.Element, Is.Null);

            // releaseNotes
            elementProperty = elementProperties["releaseNotes"];
            Assert.That(elementProperty.Kind, Is.EqualTo(ElementPropertyKind.ValueElement));
            Assert.That(elementProperty.ElementName, Is.EqualTo("releaseNotes"));
            Assert.That(
                elementProperty.Property,
                Is.SameAs(typeof(Metadata).GetProperties().Single(x => x.Name == "ReleaseNotes")));
            Assert.That(elementProperty.Element, Is.Null);

            // tags
            elementProperty = elementProperties["tags"];
            Assert.That(elementProperty.Kind, Is.EqualTo(ElementPropertyKind.ValueElement));
            Assert.That(elementProperty.ElementName, Is.EqualTo("tags"));
            Assert.That(
                elementProperty.Property,
                Is.SameAs(typeof(Metadata).GetProperties().Single(x => x.Name == "Tags")));
            Assert.That(elementProperty.Element, Is.Null);

            // dependencies
            elementProperty = elementProperties["dependencies"];
            Assert.That(elementProperty.Kind, Is.EqualTo(ElementPropertyKind.ComplexElement));
            Assert.That(elementProperty.ElementName, Is.EqualTo("dependencies"));
            Assert.That(
                elementProperty.Property,
                Is.SameAs(typeof(Metadata).GetProperties().Single(x => x.Name == "Dependencies")));
            Assert.That(elementProperty.Element, Is.SameAs(schemaDescriptor.Elements[typeof(DependenciesElement)]));

            #endregion

            #region license

            elementDescriptor = schemaDescriptor.Elements[typeof(License)];

            Assert.That(elementDescriptor.Type, Is.EqualTo(typeof(License)));

            Assert.That(elementDescriptor.AttributeProperties, Has.Count.EqualTo(1));
            Assert.That(elementDescriptor.InnerTextProperty, Is.SameAs(typeof(License).GetProperties().Single(x => x.Name == "Value")));
            Assert.That(elementDescriptor.ElementProperties, Is.Empty);

            var attributeProperties = elementDescriptor.AttributeProperties;

            var attributeProperty = attributeProperties["type"];
            Assert.That(attributeProperty.AttributeName, Is.EqualTo("type"));
            Assert.That(attributeProperty.Property, Is.SameAs(typeof(License).GetProperties().Single(x => x.Name == "Type")));

            #endregion

            #region dependencies

            elementDescriptor = schemaDescriptor.Elements[typeof(DependenciesElement)];

            Assert.That(elementDescriptor.Type, Is.EqualTo(typeof(DependenciesElement)));
            Assert.That(elementDescriptor.AttributeProperties, Is.Empty);
            Assert.That(elementDescriptor.InnerTextProperty, Is.Null);

            elementProperties = elementDescriptor.ElementProperties;
            Assert.That(elementProperties, Has.Count.EqualTo(2));

            elementProperty = elementProperties["group"];
            Assert.That(elementProperty.Kind, Is.EqualTo(ElementPropertyKind.ComplexElementList));
            Assert.That(elementProperty.ElementName, Is.EqualTo("group"));
            Assert.That(
                elementProperty.Property,
                Is.SameAs(typeof(DependenciesElement).GetProperties().Single(x => x.Name == "Groups")));
            Assert.That(elementProperty.Element, Is.SameAs(schemaDescriptor.Elements[typeof(Group)]));

            elementProperty = elementProperties["dependency"];
            Assert.That(elementProperty.Kind, Is.EqualTo(ElementPropertyKind.ComplexElementList));
            Assert.That(elementProperty.ElementName, Is.EqualTo("dependency"));
            Assert.That(
                elementProperty.Property,
                Is.SameAs(typeof(DependenciesElement).GetProperties().Single(x => x.Name == "Dependencies")));
            Assert.That(elementProperty.Element, Is.SameAs(schemaDescriptor.Elements[typeof(Dependency)]));

            #endregion

            #region group

            elementDescriptor = schemaDescriptor.Elements[typeof(Group)];

            Assert.That(elementDescriptor.Type, Is.EqualTo(typeof(Group)));
            Assert.That(elementDescriptor.AttributeProperties, Has.Count.EqualTo(1));
            Assert.That(elementDescriptor.ElementProperties, Has.Count.EqualTo(1));
            Assert.That(elementDescriptor.InnerTextProperty, Is.Null);

            attributeProperties = elementDescriptor.AttributeProperties;

            attributeProperty = attributeProperties["targetFramework"];
            Assert.That(attributeProperty.AttributeName, Is.EqualTo("targetFramework"));
            Assert.That(attributeProperty.Property, Is.SameAs(typeof(Group).GetProperties().Single(x => x.Name == "TargetFramework")));

            elementProperties = elementDescriptor.ElementProperties;
            
            elementProperty = elementProperties["dependency"];
            Assert.That(elementProperty.Kind, Is.EqualTo(ElementPropertyKind.ComplexElementList));
            Assert.That(elementProperty.ElementName, Is.EqualTo("dependency"));
            Assert.That(
                elementProperty.Property,
                Is.SameAs(typeof(Group).GetProperties().Single(x => x.Name == "Dependencies")));
            Assert.That(elementProperty.Element, Is.SameAs(schemaDescriptor.Elements[typeof(Dependency)]));

            #endregion

            #region dependency

            elementDescriptor = schemaDescriptor.Elements[typeof(Dependency)];

            Assert.That(elementDescriptor.Type, Is.EqualTo(typeof(Dependency)));

            Assert.That(elementDescriptor.AttributeProperties, Has.Count.EqualTo(2));
            Assert.That(elementDescriptor.InnerTextProperty, Is.Null);
            Assert.That(elementDescriptor.ElementProperties, Is.Empty);

            attributeProperties = elementDescriptor.AttributeProperties;

            attributeProperty = attributeProperties["id"];
            Assert.That(attributeProperty.AttributeName, Is.EqualTo("id"));
            Assert.That(attributeProperty.Property, Is.SameAs(typeof(Dependency).GetProperties().Single(x => x.Name == "Id")));

            attributeProperty = attributeProperties["version"];
            Assert.That(attributeProperty.AttributeName, Is.EqualTo("version"));
            Assert.That(attributeProperty.Property, Is.SameAs(typeof(Dependency).GetProperties().Single(x => x.Name == "Version")));

            #endregion

            #region files

            elementDescriptor = schemaDescriptor.Elements[typeof(FilesElement)];

            Assert.That(elementDescriptor.Type, Is.EqualTo(typeof(FilesElement)));
            Assert.That(elementDescriptor.AttributeProperties, Is.Empty);
            Assert.That(elementDescriptor.InnerTextProperty, Is.Null);
            Assert.That(elementDescriptor.ElementProperties, Has.Count.EqualTo(1));

            elementProperties = elementDescriptor.ElementProperties;

            elementProperty = elementProperties["file"];
            Assert.That(elementProperty.Kind, Is.EqualTo(ElementPropertyKind.ComplexElementList));
            Assert.That(elementProperty.ElementName, Is.EqualTo("file"));
            Assert.That(
                elementProperty.Property,
                Is.SameAs(typeof(FilesElement).GetProperties().Single(x => x.Name == "Files")));
            Assert.That(elementProperty.Element, Is.SameAs(schemaDescriptor.Elements[typeof(File)]));



            #endregion

            #region File

            elementDescriptor = schemaDescriptor.Elements[typeof(File)];

            Assert.That(elementDescriptor.Type, Is.EqualTo(typeof(File)));

            Assert.That(elementDescriptor.AttributeProperties, Has.Count.EqualTo(2));
            Assert.That(elementDescriptor.InnerTextProperty, Is.Null);
            Assert.That(elementDescriptor.ElementProperties, Is.Empty);

            attributeProperties = elementDescriptor.AttributeProperties;

            attributeProperty = attributeProperties["src"];
            Assert.That(attributeProperty.AttributeName, Is.EqualTo("src"));
            Assert.That(attributeProperty.Property, Is.SameAs(typeof(File).GetProperties().Single(x => x.Name == "Src")));

            attributeProperty = attributeProperties["target"];
            Assert.That(attributeProperty.AttributeName, Is.EqualTo("target"));
            Assert.That(attributeProperty.Property, Is.SameAs(typeof(File).GetProperties().Single(x => x.Name == "Target")));

            #endregion
        }
    }
}
