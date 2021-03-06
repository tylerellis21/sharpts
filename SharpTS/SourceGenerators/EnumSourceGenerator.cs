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

        Syntax:

            enum Direction {
                Up = 1,
                Down,
                Left,
                Right,
            }

        */

        private bool GenerateEnum(TypeScriptEnum tsEnum, TextWriter output) {
            output.WriteLine($"export enum {tsEnum.Name} {{");
            foreach (TypeScriptField tsField in tsEnum.Fields) {
                output.Write($"  {tsField.Name} ");
                if (tsField.Value != null) {
                    output.Write($"= {tsField.Value.ToString()}");
                }
                output.WriteLine(",");
            }
            output.WriteLine("}");
            return true;
        }
        
    } // class SharpSourceGenerator
    
} // namespace SharpTS.SourceGenerators