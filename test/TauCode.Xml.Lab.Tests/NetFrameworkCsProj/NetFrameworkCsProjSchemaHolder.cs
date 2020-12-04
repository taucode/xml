using TauCode.Xml.Lab.Fluent;

namespace TauCode.Xml.Lab.Tests.NetFrameworkCsProj
{
    public class NetFrameworkCsProjSchemaHolder
    {
        public static IElementSchema Schema { get; } = Build();

        internal static IElementSchema Build()
        {
            var schema = new ElementSchemaBuilder("Project", typeof(Project), "ToolsVersion", "DefaultTargets", "xmlns")
                .AddChildElement("Import", typeof(Import))
                .GetParent()
                .AddChildElement("PropertyGroup", typeof(PropertyGroup))
                    .AddTextNodeChildElement("Configuration")
                    .AddTextNodeChildElement("Platform")
                    .AddTextNodeChildElement("ProductVersion")
                    .AddTextNodeChildElement("SchemaVersion")
                    .AddTextNodeChildElement("ProjectGuid")
                    .AddTextNodeChildElement("ProjectTypeGuids")
                    .AddTextNodeChildElement("OutputType")
                    .AddTextNodeChildElement("AppDesignerFolder")
                    .AddTextNodeChildElement("RootNamespace")
                    .AddTextNodeChildElement("AssemblyName")
                    .AddTextNodeChildElement("TargetFrameworkVersion")
                    .AddTextNodeChildElement("MvcBuildViews")
                    .AddTextNodeChildElement("UseIISExpress")
                    .AddTextNodeChildElement("Use64BitIISExpress")
                    .AddTextNodeChildElement("IISExpressSSLPort")
                    .AddTextNodeChildElement("IISExpressAnonymousAuthentication")
                    .AddTextNodeChildElement("IISExpressWindowsAuthentication")
                    .AddTextNodeChildElement("IISExpressUseClassicPipelineMode")
                    .AddTextNodeChildElement("UseGlobalApplicationHostFile")
                    .AddTextNodeChildElement("NuGetPackageImportStamp")
                    .AddTextNodeChildElement("ApplicationInsightsResourceId")
                    .AddTextNodeChildElement("ApplicationInsightsAnnotationResourceId")
                    .AddTextNodeChildElement("DebugSymbols")
                    .AddTextNodeChildElement("DebugType")
                    .AddTextNodeChildElement("Optimize")
                    .AddTextNodeChildElement("OutputPath")
                    .AddTextNodeChildElement("DefineConstants")
                    .AddTextNodeChildElement("ErrorReport")
                    .AddTextNodeChildElement("WarningLevel")
                    .AddTextNodeChildElement("LangVersion")
                    .AddTextNodeChildElement("DocumentationFile")
                .GetParent()
                .AddChildElement("ItemGroup", typeof(ItemGroup))
                    .AddChildElement("Reference", typeof(Reference))


                //.AddChildElement("metadata", typeof(Metadata))
                //    .AddTextNodeChildElement("id")
                //    .AddTextNodeChildElement("version")
                //    .AddTextNodeChildElement("authors")
                //    .AddTextNodeChildElement("owners")
                //    .AddTextNodeChildElement("requireLicenseAcceptance")
                //    .AddTextNodeChildElement("license", "type")
                //    .AddTextNodeChildElement("projectUrl")
                //    .AddTextNodeChildElement("description")
                //    .AddTextNodeChildElement("releaseNotes")
                //    .AddTextNodeChildElement("tags")
                //    .AddChildElement("dependencies", typeof(Dependencies))
                //        .AddChildElement("group", typeof(Group))
                //            .AddChildElement("dependency", typeof(Dependency), "id", "version")
                //            .GetParent()
                //        .GetParent()
                //    .GetParent()
                //.GetParent()
                //.AddChildElement("files", typeof(Files))
                //    .AddChildElement("file", typeof(File), "src", "target")
                .Build();

            return schema;

        }
    }
}
