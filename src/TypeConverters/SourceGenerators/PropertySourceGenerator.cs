using System;
using System.IO;
using System.Collections.Generic;

using SharpTS.TypeScript;
using SharpTS.TypeScript.Types;
namespace SharpTS.SourceGenerators {  
    /*
        interface SquareConfig {
            color?: string;
            width?: number;
        }
    */
    /// <summary>
    /// This class is responsible for taking type script types and generate
    /// the appropriate source code for the input types.
    /// </summary>
    public partial class SharpSourceGenerator {
        private bool GenerateProperty(TypeScriptProperty tsProperty, TextWriter output) {
            output.Write($"{GenerateCamelCaseName(tsProperty.Name)}");
            
            if (tsProperty.IsOptional) 
                output.Write("?");
            
            output.Write(": ");

            if (tsProperty.Type.IsPrimitive) {
                GeneratePrimitive(tsProperty.Type as TypeScriptPrimitive, output);
            }
            else if (tsProperty.Type.IsArray) {
                GenerateArray(tsProperty.Type as TypeScriptArray, output);
            }
            else { 
                output.Write(tsProperty.Type.Name);
            }
            
            output.WriteLine(';');

            //output.WriteLine($": {tsProperty.Type.Name};");
            return true;
        }
        
    } // class SharpSourceGenerator
    
} // namespace SharpTS.SourceGenerators