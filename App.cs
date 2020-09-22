using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Diagnostics;

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
                    } break;

                    case "-in":
                    case "-i":  {
                        if (i + 1 > args.Length) {
                            Console.WriteLine("no input assembly specified!");
                            return;
                        }
                        input_files.Add(args[i + 1]);
                    } break;

                    case "-out":
                    case "-o": {
                        if (i + 1 > args.Length) {
                            Console.WriteLine("no namespace specified!");
                            return;
                        }                                         
                        output_dir = args[i + 1];
                    } break;

                } // switch
            } // for
        } // ParseArguments

        // Begin the process of generating typescript.
        // 1. We must search for the types we need to processes.
        // 2. Generate the appopriate typescript files for each type we are processing.
        void Run(string[] args) {
            
            ParseArguments(args);

            //Assembly assembly = Assembly.GetCallingAssembly();

            //List<Type> types = SearchNamespaceType(assembly, input_namespace);
        }
/*
        static List<Type> SearchNamespaceType(Assembly assembly, string name) {
            List<Type> types = new List<Type>();

            Type[] assembly_types = assembly.GetTypes();

            foreach (Type type in assembly_types) {
                Console.WriteLine($"{type.Attributes} {type.FullName}");
            }

            return types;
        }
*/
    } // class Program
} // namespace SharpTS
