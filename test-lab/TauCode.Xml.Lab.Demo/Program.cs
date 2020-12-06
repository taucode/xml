using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using TauCode.Algorithms.Graphs;
using TauCode.Xml.Lab.Demo.NetCoreCsProj;
using TauCode.Xml.Lab.Demo.Nuspec;
using File = System.IO.File;

namespace TauCode.Xml.Lab.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var dirPath = @"C:\work\tau\lib";
            var dir = new DirectoryInfo(dirPath);

            var libDirs = dir.GetDirectories();

            var libs = new List<Lib>();

            foreach (var libDir in libDirs)
            {
                var slnFiles = libDir.GetFiles("*.sln");

                if (slnFiles.Length == 0)
                {
                    continue;
                }

                if (slnFiles.Length != 1)
                {
                    throw new NotImplementedException();
                }

                var slnFile = slnFiles.Single();
                var libName = Path.GetFileNameWithoutExtension(slnFile.Name);

                if (!libDir.ContainsSubDirectory("nuget"))
                {
                    continue;
                }


                var nuspecFile = libDir.GetSubDirectory("nuget").GetFiles("*.nuspec").Single();
                var csProjFile = libDir.GetSubDirectory($"src/{libName}").GetFiles("*.csproj").Single();

                var serializer = new Serializer();

                var nuspecDocContent = File.ReadAllText(nuspecFile.FullName, Encoding.UTF8);
                var nuspecDoc = new XmlDocument();
                nuspecDoc.LoadXml(nuspecDocContent);
                var package = (Package)serializer.Deserialize(NuspecSchemaHolder.Schema, nuspecDoc);

                var csProjDocContent = File.ReadAllText(csProjFile.FullName, Encoding.UTF8);
                var csProjDoc = new XmlDocument();
                csProjDoc.LoadXml(csProjDocContent);
                var csProj = (Project)serializer.Deserialize(NetCoreCsProjSchemaHolder.Schema, csProjDoc);

                var lib = new Lib
                {
                    Package = package,
                    Project = csProj,
                };

                libs.Add(lib);
            }

            var libDict = libs.ToDictionary(x => x.Package.GetId(), x => x);

            var graph = new Graph<Lib>();


            foreach (var lib in libs)
            {
                graph.AddNode(lib);
            }

            foreach (var node in graph.Nodes)
            {
                var lib = node.Value;

                var dependencies = lib.Package
                    .GetAllDependencies()
                    .Where(x => x.GetId().StartsWith("TauCode."))
                    .ToList();

                foreach (var dependency in dependencies)
                {
                    var dependencyNode = graph.Nodes.Single(x => x.Value.Id == dependency.GetId());
                    var dependencyLib = dependencyNode.Value;

                    node.DrawEdgeTo(dependencyNode);
                }
            }

            var alg = new GraphSlicingAlgorithm<Lib>(graph);

            var slices = alg.Slice();

            var sb = new StringBuilder();

            for (var i = 0; i < slices.Length; i++)
            {
                sb.AppendLine($"=== Generation {i} ===");
                sb.AppendLine();

                var slice = slices[i];

                var sliceLibs = slice.Nodes
                    .OrderBy(x => x.Value.Id)
                    .ToList();

                foreach (var sliceLib in sliceLibs)
                {
                    sb.AppendLine(sliceLib.Value.Id);
                }

                sb.AppendLine();
            }
            
            var report = sb.ToString();

            throw new NotImplementedException();
        }
    }
}
