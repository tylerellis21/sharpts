using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Diagnostics;

using SharpTS.TypeScript;
using SharpTS.TypeScript.Types;

namespace SharpTS.TypeScript {

    public class TypeScriptGenerator {
        
        public string OutputDir { get; }

        public TypeScriptGenerator(string output_dir) {
            this.OutputDir = output_dir;
        }

        public bool Generate(ref List<TypeScriptType> types) {
            return true;
        }
    
    } // class TypeScriptGenerator
    
} // namespace SharpTS.TypeScript 
 