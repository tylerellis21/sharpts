using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Diagnostics;

using SharpTS.Reflection;
using SharpTS.TypeScript;
using SharpTS.TypeScript.Types;

using SharpTS.TypeConverters;
using SharpTS.SourceGenerators;
using SharpTS.Utils;

namespace SharpTS {

    public class App {

        static void Main(string[] args) => (new App()).Run(args);

        public static string ProjectPath;

        public static ProjectFile Project;

        /*
            TODO(@Tyler):
                - Can we generate the ajax functions to invoke the correct api function/urlpath as needed automatically?
        */

        // Begin the process of generating typescript.
        // 1. We must search for the types we need to processes.
        // 2. Generate the appopriate typescript files for each type we are processing.
        void Run(string[] args) {

            if (args.Length > 0) {
                if (args[0] == "-g") {
                    string path = args[1];
                    ProjectFile exampleProject = new ProjectFile();

                    exampleProject.InputAssemblies = new string[] { "test.dll" };
                    exampleProject.OutputDirectory = "./ts";
                    exampleProject.Rules = new TypeRule[] {
                        new TypeRule() {
                            EnableClassGeneration = true,
                            EnableEnumGeneration = true,
                            EnableInterfaceGeneration = true,
                            Pattern = "InsertRegexHere"
                        }
                    };

                    ConfigFile.Save(path, exampleProject);
                    Logger.Info($"generated default project file: {path}");
                    return;
                }
            }

            if (args.Length == 0) {
                Logger.Error("no project file specified");
                Logger.Error("sharpts <path/to/project.json>");
                return;
            }

            ProjectPath = args[0];

            if (ConfigFile.Load<ProjectFile>(ProjectPath, out Project) == false) {
                Logger.Error($"failed to open project file: {ProjectPath}");
                return;
            }

            List<Type> types = TypeReflection.Load(Project);

            SharpTypeConverter typeConverter
                = new SharpTypeConverter(types);

            if (typeConverter.Convert() == false) {
                Console.WriteLine("failed during conversion of c# types into typescript types");
                return;
            }

            SharpSourceGenerator sourceGenerator
                = new SharpSourceGenerator(Project.OutputDirectory, typeConverter.MappedTypes);

            sourceGenerator.Generate();

        } // void Run

    } // class Program

} // namespace SharpTS
