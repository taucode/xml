using TauCode.Xml.Fluent;

namespace TauCode.Xml.Tests.NetCoreCsProj
{
    public class NetCoreCsProjSchemaHolder
    {
        public static IElementSchema Schema { get; } = Build();

        internal static IElementSchema Build()
        {
            var schema = new ElementSchemaBuilder("Project", typeof(Project), "Sdk")
                .AddChildElement("PropertyGroup", typeof(PropertyGroup))
                    .AddTextNodeChildElement("TargetFramework")
                    .AddTextNodeChildElement("IsPackable")
                    .AddTextNodeChildElement("AssemblyName")
                    .AddTextNodeChildElement("RootNamespace")
                .GetParent()
                .AddChildElement("ItemGroup", typeof(ItemGroup))
                    .AddTextNodeChildElement("None")
                    .AddTextNodeChildElement("EmbeddedResource")
                    .AddTextNodeChildElement("ProjectReference")
                    .AddChildElement("PackageReference", typeof(PackageReference))
                        .AddTextNodeChildElement("PrivateAssets")
                        .AddTextNodeChildElement("IncludeAssets")

                .Build();

            return schema;
        }
    }
}
