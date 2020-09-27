using System;

namespace SharpTS.TypeScript.Types {

    public enum TSBasicType { 
        TSNull = 0,
        TSAny,
        TSBoolean, 
        TSNumber,
        TSString
    }

    public class TypeScriptBasicType : TypeScriptType {

        public TSBasicType Type { get; set; }

        public TypeScriptBasicType(string name, TSBasicType type) :
            base(name) {
            this.Type = type;
        }
    }

} // namespace SharpTS.TypeScript.Types