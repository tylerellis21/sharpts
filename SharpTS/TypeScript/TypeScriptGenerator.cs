using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Diagnostics;

namespace SharpTS.TypeScript {

    public class TypeScriptGenerator {
        
        public string OutputDir { get; }

        public TypeScriptGenerator(string output_dir) {
            this.OutputDir = output_dir;
        }

        public bool Generate(Type type) {
            Console.WriteLine($"INFO: generating type for '{type.FullName}'");
            return true;
        }

        public bool Generate(ref List<Type> types) {
            foreach (Type type in types) {
                if (Generate(type) == false) {
                    Console.Write($"ERROR: failed to generate type for '{type.FullName}'");
                }
            }
            return true;
        }
    
    } // class TypeReflection
    
} // namespace SharpTS.TypeScript 
 