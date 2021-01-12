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
        private bool GenerateField(TypeScriptField tsField, TextWriter output) {
            output.Write($"{GenerateCamelCaseName(tsField.Name)}: {tsField.Type.Name}");
            output.WriteLine(";");
            return true;
        }
        
    } // class SharpSourceGenerator
    
} // namespace SharpTS.SourceGenerators