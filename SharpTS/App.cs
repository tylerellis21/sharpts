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

namespace SharpTS {

    internal class Program {

        static void Main(string[] args) => (new Program()).Run(args); 
            
        // The list of .net assembly files we will be searching for type definitions in.
        static List<string> input_files = new List<string>();

        // The list of namespaces we are processing.
        static List<string> input_namespaces = new List<string>();

        // By default we will just dump to the current working directory.
        static string output_dir = "./";

        void ParseArguments(string[] args) {
            // We could probably do this a better way but i just quickly wrote this argument parsing.
            for (int i = 0; i < args.Length; i++) {
                switch (args[i]) {
                    default: 
                        Console.WriteLine($"unknown argument: '{args[i]}'"); 
                    break;
                    
                    case "-n":
                    case "-namespace": {
                        if (i + 1 > args.Length) {
                            Console.WriteLine("no namespace specified!");
                            return;
                        }
                        input_namespaces.Add(args[i + 1]);
                        i++;
                    } break;

                    case "-in":
                    case "-i":  {
                        if (i + 1 > args.Length) {
                            Console.WriteLine("no input assembly specified!");
                            return;
                        }
                        input_files.Add(args[i + 1]);
                        i++;
                    } break;

                    case "-out":
                    case "-o": {
                        if (i + 1 > args.Length) {
                            Console.WriteLine("no namespace specified!");
                            return;
                        }                                         
                        output_dir = args[i + 1];
                        i++;
                    } break;

                } // switch
            } // for
        } // ParseArguments

        /*
            TODO(@Tyler):
                - Can we generate the ajax functions to invoke the correct api function/urlpath as needed automatically? 
        */
/*
"args": [
    "-o", "./ts",
    "-i", "./wp.common.dll",
    "-n", "^(WP.Common.*)",
],
*/
        // Begin the process of generating typescript.
        // 1. We must search for the types we need to processes.
        // 2. Generate the appopriate typescript files for each type we are processing.
        void Run(string[] args) {
            ParseArguments(args);
            
            TypeRules type_rules = new TypeRules() {
                RegexPattern = "^(WP.Common.ApiResult)",
                EnableClasses = true,
                EnableInterfaces = true, 
                EnableRegexFilter = true
            };

            List<Type> types = TypeReflection.Load(
                type_rules, 
                ref input_files, 
                ref input_namespaces
            );
            
            SharpTypeConverter typeConverter 
                = new SharpTypeConverter(types);
            
            if (typeConverter.Convert() == false) {
                Console.WriteLine("failed during conversion of c# types into typescript types");
                return;
            }

            SharpSourceGenerator sourceGenerator
                = new SharpSourceGenerator(output_dir, typeConverter.MappedTypes);

            sourceGenerator.Generate();
            
        } // void Run

    } // class Program

} // namespace SharpTS
