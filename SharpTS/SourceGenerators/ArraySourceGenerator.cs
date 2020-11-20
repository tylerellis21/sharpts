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
        private bool GenerateArray(TypeScriptArray tsArray, TextWriter output) {
            return true;
        }
        
    } // class SharpSourceGenerator
    
} // namespace SharpTS.SourceGenerators