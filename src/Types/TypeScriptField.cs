using System;
using System.Text;

namespace SharpTS.TypeScript.Types {
    public class TypeScriptField : TypeScriptType { 

        public object Value { get; }
        public TypeScriptType Type { get; set; }

        public TypeScriptField(string name, object value, TypeScriptType type) :
            base(name) {
            this.IsField = true;
            this.Type = type;
            this.Value = value;
        }
        
    } // class TypeScriptField

} // namespace SharpTS.TypeScript.Types