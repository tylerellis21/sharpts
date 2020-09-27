using System;

namespace SharpTS.TypeScript.Types {

    public class TypeScriptArray : TypeScriptType { 
        
        public TypeScriptType Type { get; set; }

        public TypeScriptArray(string name, TypeScriptType type) :
            base(name) {
            this.Type = type;
        }
    }

} // namespace SharpTS.TypeScript.Types