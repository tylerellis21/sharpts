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
            output.Write($"{tsProperty.Name}");
            
            if (tsProperty.IsOptional) 
                output.Write("?");
            
            output.Write(": ");
            
            // If it's a class we don't need to generate the full source
            // Just reference using the name
            if (tsProperty.Type.IsClass == true) {
                output.Write(tsProperty.Type.Name);
            }
            else if (GenerateType(tsProperty.Type, output) == false) 
                return false;
            
            output.WriteLine(';');

            //output.WriteLine($": {tsProperty.Type.Name};");
            return true;
        }
        
    } // class SharpSourceGenerator
    
} // namespace SharpTS.SourceGenerators