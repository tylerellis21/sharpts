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
        private bool GeneratePrimitive(TypeScriptPrimitive tsPrimitive, TextWriter output) {
            switch (tsPrimitive.Type) {
            case TSPrimitiveType.TSAny: output.Write("any"); break;
            case TSPrimitiveType.TSBoolean: output.Write("boolean"); break;
            case TSPrimitiveType.TSDate: output.Write("Date"); break;
            case TSPrimitiveType.TSNull: output.Write("null"); break;
            case TSPrimitiveType.TSNumber: output.Write("number"); break;
            case TSPrimitiveType.TSString: output.Write("string"); break;
            case TSPrimitiveType.TSVoid: output.Write("void"); break;
            default: return false;
            } // switch 
            return true;
        }
        
    } // class SharpSourceGenerator
    
} // namespace SharpTS.SourceGenerators