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

        public TypeScriptBasicType(TSBasicType type) {
            this.Type = type;
        }
    }

} // namespace SharpTS.TypeScript.Types