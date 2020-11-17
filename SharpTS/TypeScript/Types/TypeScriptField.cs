using System;
using System.Text;

namespace SharpTS.TypeScript.Types {
    public class TypeScriptField : TypeScriptType { 

        public TypeScriptType Type { get; set; }

        public TypeScriptField(string name, TypeScriptType type) :
            base(name) {
            this.IsField = true;
            this.Type = type;
        }
        
    } // class TypeScriptField

} // namespace SharpTS.TypeScript.Types