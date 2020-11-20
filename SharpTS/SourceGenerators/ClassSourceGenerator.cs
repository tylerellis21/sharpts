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
            output.WriteLine($"export class {tsClass.Name} {{");
            foreach (TypeScriptProperty prop in tsClass.Properties) {
                GenerateProperty(prop, output);
            }
            output.WriteLine("}");
            return true;
        }
        
    } // class SharpSourceGenerator
    
} // namespace SharpTS.SourceGenerators