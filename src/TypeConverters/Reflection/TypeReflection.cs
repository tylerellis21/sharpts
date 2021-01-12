using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Loader;
using System.Diagnostics;

using SharpTS.Utils;

namespace SharpTS.Reflection {

    /// <summary>
    /// The TypeReflection class handles all reflection tasks, such as loading assemblies and
    /// Finding the types which are to be transpiled.
    /// </summary>
    public static class TypeReflection {

        /// <summary>
        /// Load the assemblies contained in the given file paths.
        /// </summary>
        /// <param name="files">The list of dotnet assemblies to search</param>
        /// <returns>All of the assemblies that were loaded</returns>
        public static List<Assembly> LoadAssemblies(string[] files) {

            List<Assembly> assemblies
                = new List<Assembly>();

            foreach (string assembly_path in files) {

                // We must use a full file path when loading modules.
                string full_assembly_path = Path.GetFullPath(assembly_path);

                // By default we just print a warning and carry on.
                // Do we want this as a flag to change that logic to exit out in the case of a missing file??
                if (File.Exists(full_assembly_path) == false) {
                    Logger.Warn($"WARNING: skipping generation of '{full_assembly_path}' failed to open file");
                    continue;
                }

                try {

                    Assembly assembly
                        = AssemblyLoadContext.Default.LoadFromAssemblyPath(full_assembly_path);

                    if (assembly == null) {

                        Logger.Error(
                            $"ERROR: failed to load '{assembly_path}' for an unknown reason?!?"
                        );

                        continue;
                    } // if

                    assemblies.Add(assembly);

                } // try
                catch(Exception e) {

                    Logger.Error(
                        $"ERROR: failed to load '{assembly_path}' an exception occured during the assembly loading!"
                    );

                    Logger.Error($"EXCEPTION: {e.Message}");

                } // catch

            } // foreach

            return assemblies;
        }

        public static List<Type> Load(ProjectFile project) {

            List<Assembly> assemblies
                 = LoadAssemblies(project.InputAssemblies);

            List<Type> results = new List<Type>();

            foreach (Assembly assembly in assemblies) {

                foreach (Type type in assembly.GetExportedTypes()) {

                    foreach (TypeRule rule in project.Rules) {
                        if (rule.Include) {
                            Logger.Info($"type '{type.ToString()}' included by rule '{rule.Pattern}'");
                            if (rule.Match(type)) {
                                results.Add(type);
                            }
                        }
                        else {
                            if (rule.Match(type) == false) {
                                results.Add(type);
                            }
                            Logger.Info($"type '{type.ToString()}' excluded by rule '{rule.Pattern}'");
                        }
                    }
                }
            }

            return results;
        }

    } // class TypeReflection

} // namespace SharpTS.Reflection
