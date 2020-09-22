using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Diagnostics;

namespace sharpts {

    internal class Program {

        static void Main(string[] args) => (new Program()).Run(args); 

        void Run(string[] args) {
            string input_namespace = "WP.Models";

            string[] input_files;
            string output_dir;
            
            Assembly assembly = Assembly.GetCallingAssembly();

            List<Type> types = SearchNamespaceType(assembly, input_namespace);
        }

        static List<Type> SearchNamespaceType(Assembly assembly, string name) {
            List<Type> types = new List<Type>();

            Type[] assembly_types = assembly.GetTypes();

            foreach (Type type in assembly_types) {
                Console.WriteLine($"{type.Attributes} {type.FullName}");
            }

            return types;
        }

    } // class Program
} // namespace sharpts
