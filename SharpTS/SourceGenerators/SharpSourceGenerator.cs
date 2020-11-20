using System;
using System.IO;
using System.Collections.Generic;

using SharpTS.TypeScript;
using SharpTS.TypeScript.Types;
namespace SharpTS.SourceGenerators {  

    /// <summary>
    /// This class is responsible for taking type script types and generate
    /// the appropriate source code for the input types.
    /// </summary>
    public partial class SharpSourceGenerator {
        public string OutputDir { get; }

        public List<TypeScriptType> Types { get; set; }

        public SharpSourceGenerator(string outputDir, List<TypeScriptType> types) {
            this.OutputDir = outputDir;
            this.Types = types;
        }

        public void Generate() {
            foreach (TypeScriptType type in Types) {
                BeginGenerateType(type);
            }
        }

        private void BeginGenerateType(TypeScriptType type) {
            string path = $"{OutputDir}/{type.Name}.ts";

            // Remove any old generated files.
            // TODO: Just change the file mode lol.
            if (File.Exists(path)) {
                File.Delete(path);
            }

            TextWriter output = new StreamWriter(File.OpenWrite(path));

            Console.WriteLine($"generating source for type: {type.Name} {type.GetType().GUID}");
            Console.WriteLine($"path: {path}\n"); 

            GenerateType(type, output); 

            output.Flush();
            output.Close();
        }

        private bool GenerateType(TypeScriptType type, TextWriter output) {
            if (type.IsArray) {
                return GenerateArray(type as TypeScriptArray, output);
            }
            else if (type.IsClass) {
                return GenerateClass(type as TypeScriptClass, output);
            }
            else if (type.IsEnum) {
                return GenerateEnum(type as TypeScriptEnum, output);
            }
            else if (type.IsField) {
                return GenerateField(type as TypeScriptField, output);
            }
            else if (type.IsInterface) {
                return GenerateInterface(type as TypeScriptInterface, output);
            }
            else if (type.IsMethod) {
                return GenerateMethod(type as TypeScriptMethod, output);
            }
            else if (type.IsPrimitive) {
                return GeneratePrimitive(type as TypeScriptPrimitive, output);
            }
            else if (type.IsProperty) {
                return GenerateProperty(type as TypeScriptProperty, output);
            }
            
            throw new Exception($"failed to generate source for type: {type.Name}");

            return false;
        
        }

    } // class SharpSourceGenerator
    
} // namespace SharpTS.SourceGenerators