using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using AutoGen.Application;

namespace AutoGeneratorReplay
{
    class Program
    {
        static void Main(string[] args)
        {
            var solution_dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var filePath = solution_dir + "/PersonStudentEntities.json";
            var targetPath = System.Environment.CurrentDirectory.ToString() + "/";

            var dependencies = new List<string>
            {
                "System",
                "System.Collections.Generic"
            };
            var interfaceNamespace = "AutoGeneratorReplay.Contracts";

            var app = new AutoGeneratorApplication()
                    .WithInterfaceGenerator(interfaceNamespace, targetPath)
                    .WithInterfaceDependencies(dependencies)
                    .Build();

            app.Run(filePath);

            //Console.WriteLine("Hello World!");
        }
    }
}
