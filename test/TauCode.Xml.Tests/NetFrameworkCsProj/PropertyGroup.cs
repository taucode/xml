using System.Collections.Generic;
using TauCode.Xml.Attributes;

namespace TauCode.Xml.Tests.NetFrameworkCsProj
{
    public class PropertyGroup
    {
        [XmlAttributeProperty]
        public string Condition { get; set; }

        [XmlElementProperty]
        public Configuration Configuration { get; set; }

        [XmlElementProperty]
        public Platform Platform { get; set; }

        [XmlElementProperty]
        public string ProductVersion { get; set; }

        [XmlElementProperty]
        public string SchemaVersion { get; set; }

        [XmlElementProperty]
        public string ProjectGuid { get; set; }

        [XmlElementProperty]
        public string ProjectTypeGuids { get; set; }

        [XmlElementProperty]
        public string OutputType { get; set; }

        [XmlElementProperty]
        public string AppDesignerFolder { get; set; }

        [XmlElementProperty]
        public string RootNamespace { get; set; }

        [XmlElementProperty]
        public string AssemblyName { get; set; }

        [XmlElementProperty]
        public string TargetFrameworkVersion { get; set; }

        [XmlElementProperty]
        public string MvcBuildViews { get; set; }

        [XmlElementProperty]
        public string UseIISExpress { get; set; }

        [XmlElementProperty]
        public string Use64BitIISExpress { get; set; }

        [XmlElementProperty]
        public string IISExpressSSLPort { get; set; }

        [XmlElementProperty]
        public string IISExpressAnonymousAuthentication { get; set; }

        [XmlElementProperty]
        public string IISExpressWindowsAuthentication { get; set; }

        [XmlElementProperty]
        public string IISExpressUseClassicPipelineMode { get; set; }

        [XmlElementProperty]
        public string UseGlobalApplicationHostFile { get; set; }

        [XmlElementProperty]
        public string NuGetPackageImportStamp { get; set; }

        [XmlElementProperty]
        public string ApplicationInsightsResourceId { get; set; }

        [XmlElementProperty]
        public string ApplicationInsightsAnnotationResourceId { get; set; }

        [XmlElementProperty]
        public string DebugSymbols { get; set; }

        [XmlElementProperty]
        public string DebugType { get; set; }

        [XmlElementProperty]
        public string Optimize { get; set; }

        [XmlElementProperty]
        public string OutputPath { get; set; }

        [XmlElementProperty]
        public string DefineConstants { get; set; }

        [XmlElementProperty]
        public string ErrorReport { get; set; }

        [XmlElementProperty]
        public string WarningLevel { get; set; }

        [XmlElementProperty]
        public string LangVersion { get; set; }

        [XmlElementProperty]
        public string DocumentationFile { get; set; }

        [XmlElementProperty]
        public VisualStudioVersion VisualStudioVersion { get; set; }

        [XmlElementProperty]
        public VSToolsPath VSToolsPath { get; set; }

        [XmlElementProperty]
        public ErrorText ErrorText { get; set; }

        [XmlElementProperty]
        public IList<PostBuildEvent> PostBuildEvent { get; set; } = new List<PostBuildEvent>();

        [XmlElementProperty]
        public IList<PreBuildEvent> PreBuildEvent { get; set; } = new List<PreBuildEvent>();

    }
}
