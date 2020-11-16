using System;

namespace SharpTS.TypeScript.Types {
    public class TypeScriptBasicType : TypeScriptType {

        public TSBasicType Type { get; set; }

        public TypeScriptBasicType(string name, TSBasicType type) :
            base(name) {
            this.Type = type;
        }
    } 
} // namespace SharpTS.TypeScript.Types