using TauCode.Xml.Lab.Fluent;

namespace TauCode.Xml.Lab.Tests.Nuspec
{
    public class NuspecSchemaHolder
    {
        public static IElementSchema Schema { get; } = Build();

        internal static IElementSchema Build()
        {
            var schema = new ElementSchemaBuilder("package", typeof(Package), "xmlns")
                    .AddChildElement("metadata", typeof(Metadata))
                        .AddTextNodeChildElement("id")
                        .AddTextNodeChildElement("version")
                        .AddTextNodeChildElement("authors")
                        .AddTextNodeChildElement("owners")
                        .AddTextNodeChildElement("requireLicenseAcceptance")
                        .AddTextNodeChildElement("license", "type")
                        .AddTextNodeChildElement("projectUrl")
                        .AddTextNodeChildElement("description")
                        .AddTextNodeChildElement("releaseNotes")
                        .AddTextNodeChildElement("tags")
                        .AddChildElement("dependencies", typeof(Dependencies))
                            .AddChildElement("group", typeof(Group))
                                .AddChildElement("dependency", typeof(Dependency), "id", "version")
                                .GetParent()
                            .GetParent()
                        .GetParent()
                    .GetParent()
                    .AddChildElement("files", typeof(Files))
                        .AddChildElement("file", typeof(File), "src", "target")
                .Build();

            return schema;
        }
    }
}
