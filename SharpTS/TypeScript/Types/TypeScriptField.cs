using System;

namespace SharpTS.TypeScript.Types {

    public class TypeScriptField : TypeScriptType { 

        public TypeScriptType Type { get; set; }

        public TypeScriptField(string name, TypeScriptType type) :
            base(name) {
            this.Type = type;
        }
    } // class TypeScriptField

} // namespace SharpTS.TypeScript.Types