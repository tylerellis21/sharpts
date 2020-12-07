using System;
using System.Text;
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
        private static string GenerateCamelCaseName(string name) {
            StringBuilder sb = new StringBuilder();
            sb.Append(Char.ToLower(name[0]));
            sb.Append(name.Substring(1, name.Length - 1));
            return sb.ToString();
        }
        
    } // class SharpSourceGenerator
    
} // namespace SharpTS.SourceGenerators