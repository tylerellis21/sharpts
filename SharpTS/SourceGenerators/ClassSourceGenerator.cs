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
        /*
            class Greeter {
                greeting: string;
            }
        */
        private bool GenerateClass(TypeScriptClass tsClass, TextWriter output) {
            if (GenerateImports(tsClass, output) == false) {
                return false;
            }
            output.Write($"export interface {tsClass.Name} ");
            
            // Don't extend object, no need.
            if (tsClass.BaseType != null && tsClass.BaseType.Name != "Object") {
                output.Write($"extends {tsClass.BaseType.Name} ");
            }

            if (tsClass.ImplementedInterfaces.Count > 0) {
                output.Write("implements ");
                for (int i = 0; i < tsClass.ImplementedInterfaces.Count; i++) {
                    TypeScriptType tsType = tsClass.ImplementedInterfaces[i];
                    output.Write($"{tsType.Name}");
                    if (i + 1 < tsClass.ImplementedInterfaces.Count) {
                        output.Write(',');
                    }
                }
            }

            output.WriteLine('{');
            foreach (TypeScriptProperty prop in tsClass.Properties) {
                // Indent
                output.Write("  ");
                GenerateProperty(prop, output);
            }
            output.WriteLine("}");
            return true;
        }
        
    } // class SharpSourceGenerator
    
} // namespace SharpTS.SourceGenerators