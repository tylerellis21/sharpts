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

        // Generate a list of imported type names and write them out as
        // TypeScript module import statements
        private bool GenerateImports(TypeScriptClass tsClass, TextWriter output) {
            // tsClass.BaseType;
            // tsClass.Fields;
            // tsClass.Properties;


            // We gather a list of imported type names because we don't 
            // want to import a typename more than once
            List<string> importedTypes = new List<string>();

            
            if (tsClass.BaseType != null) {
                string typeName = tsClass.BaseType.Name;
                if (importedTypes.Contains(typeName) == false) {
                    if (typeName.Length > 0)
                        importedTypes.Add(typeName);
                }
            }

            foreach (TypeScriptProperty prop in tsClass.Properties) {
                
                // No need to import generated types.
                if (prop.Type.IsPrimitive) continue;

                string typeName = prop.Type.Name;
                if (importedTypes.Contains(typeName) == false) {
                    if (typeName.Length > 0)
                        importedTypes.Add(typeName);
                }
            }

            foreach (TypeScriptField field in tsClass.Fields) {
                
                // No need to import generated types.
                if (field.Type.IsPrimitive) continue;

                string typeName = field.Type.Name;
                if (importedTypes.Contains(typeName) == false) {
                    if (typeName.Length > 0)
                        importedTypes.Add(typeName);
                }

            }
            
            output.WriteLine("// GENERATED FILE - DON'T EDIT MANUALLY");
            output.WriteLine("// BEGIN IMPORTS");

            // Finally write the file after we gather all of the unique imports required
            foreach (string import in importedTypes) {

                // Don't import Object
                // HMM Figure out where this is being imported from
                if (import == "Object") continue;

                // Don't import self referencing types
                if (import == tsClass.Name) continue;

                output.WriteLine($"import {{ {import} }} from './{import}'");
            }

            output.WriteLine("// END IMPORTS\n");

            return true;
        }
        
    } // class SharpSourceGenerator
    
} // namespace SharpTS.SourceGenerators