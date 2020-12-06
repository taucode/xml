using TauCode.Xml.Lab.Demo.NetCoreCsProj;
using TauCode.Xml.Lab.Demo.Nuspec;

namespace TauCode.Xml.Lab.Demo
{
    public class Lib
    {
        public Package Package { get; set; }
        public Project Project { get; set; }


        public string Id => this.Package.GetId();
    }
}
