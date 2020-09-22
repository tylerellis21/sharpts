using System;

namespace SharpTS.TypeScript.Types {

    public class TypeScriptArray : TypeScriptType { 
        
        public TypeScriptType Type { get; set; }

        public TypeScriptArray(TypeScriptType type) {
            this.Type = type;
        }
    }

} // namespace SharpTS.TypeScript.Types