using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Diagnostics;

using SharpTS.TypeScript;
using SharpTS.TypeScript.Types;

namespace SharpTS.TypeScript {

    public class TypeScriptGenerator {
        
        public string OutputDir { get; }

        private TypeScriptTypeTranslator tsTypeTranslator;

        public TypeScriptGenerator(string output_dir) {
            this.OutputDir = output_dir;
            this.tsTypeTranslator = new TypeScriptTypeTranslator();
        }

        public string Generate(Type type) {
            
            Console.WriteLine($"INFO: generating type for '{type.FullName}'");
            
            TypeScriptType tstype 
                = tsTypeTranslator.Translate(type);

            return tstype.Generate();
        }

        public bool Generate(ref List<Type> types) {
            foreach (Type type in types) {
                
                string path = $"{OutputDir}/{type.Name}.ts";

                TextWriter writer = new StreamWriter(path, false);

                string line = Generate(type);

                writer.WriteLine(line);

                writer.Flush();
                writer.Close();
                //Console.Write($"ERROR: failed to generate type for '{type.FullName}'");
            }
            return true;
        }
    
    } // class TypeReflection
    
} // namespace SharpTS.TypeScript 
 