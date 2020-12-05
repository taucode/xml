using System.IO;
using System.Linq;

namespace TauCode.Xml.Lab.Demo
{
    public static class Extensions
    {
        public static DirectoryInfo GetSubDirectory(this DirectoryInfo directory, string subDirectoryName)
        {
            return directory.GetDirectories(subDirectoryName).Single();
        }

        public static bool ContainsSubDirectory(this DirectoryInfo directory, string subDirectoryName)
        {
            return directory.GetDirectories(subDirectoryName).Length > 0;
        }
    }
}
