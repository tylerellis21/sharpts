using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Diagnostics;

namespace SharpTS.Reflection {

    /// <summary>
    /// The TypeReflection class
    /// </summary>
    public static class TypeReflection {

        /// <summary>
        /// Load the assemblies contained in the given file paths.
        /// </summary>
        /// <param name="files">The list of dotnet assemblies to search</param>
        /// <returns>All of the assemblies that were loaded</returns>
        public static List<Assembly> LoadAssemblies(List<string> files) {
            
            List<Assembly> assemblies 
                = new List<Assembly>();
            
            foreach (string assembly_path in files) {
                
                // By default we just print a warning and carry on.
                // Do we want this as a flag to change that logic to exit out in the case of a missing file??
                if (File.Exists(assembly_path) == false) {
                    Console.WriteLine($"WARNING: skipping generation of '{assembly_path}' failed to open file");
                    continue;
                }

                try {
                    Assembly assembly 
                        = Assembly.LoadFile(assembly_path);

                    if (assembly == null) {

                        Console.WriteLine(
                            $"ERROR: failed to load '{assembly_path}' for an unknown reason?!?"
                        );

                        continue;
                    } // if

                    assemblies.Add(assembly);

                } // try
                catch(Exception e) {

                    Console.WriteLine(
                        $"ERROR: failed to load '{assembly_path}' an exception occured during the assembly loading!"
                    );

                    Console.WriteLine($"EXCEPTION: {e.Message}");

                } // catch

            } // foreach

            return assemblies;
        }
        
        public static void FindTypes(
            TypeRules type_rules, 
            Assembly assembly, 
            ref List<Type> results) {

            Type[] assembly_types = assembly.GetTypes();
            foreach (Type type in assembly_types) {
                if (type_rules.Check(type)) {
                    results.Add(type); 
                }   
            }
        }

        public static void FindTypes(
            TypeRules type_rules,
            List<Assembly> assemblies, 
            ref List<Type> results) {
        
            foreach (Assembly assembly in assemblies) {
                FindTypes(type_rules, assembly, ref results);
            }
        }

        // 
        public static List<Type> Load(
            TypeRules type_rules,
            ref List<string> input_assemblies, 
            ref List<string> input_namespaces) {

            List<Assembly> assemblies
                 = LoadAssemblies(input_assemblies);

            List<Type> results = new List<Type>();

            FindTypes(type_rules, assemblies, ref results);

            return results;
        }

    } // class TypeReflection
    
} // namespace SharpTS.Reflection
 