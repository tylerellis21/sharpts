using System;
using System.IO;

namespace SharpTS.TypeScript.Types {

    public class TypeScriptArray : TypeScriptType { 
        
        public TypeScriptType Type { get; set; }

        public TypeScriptArray(string name, TypeScriptType type) :
            base(name) {
            this.Type = type;
        }

    } // class TypeScriptArray

} // namespace SharpTS.TypeScript.Types