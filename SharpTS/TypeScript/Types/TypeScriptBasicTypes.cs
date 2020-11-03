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

        public override string Generate() {
            switch (Type) {
            default: throw new Exception("unhandled basic type in generate");
            case TSBasicType.TSAny: return "any";
            case TSBasicType.TSBoolean: return "boolean";
            case TSBasicType.TSNull: return "null";
            case TSBasicType.TSNumber: return "number";
            case TSBasicType.TSString: return "string";
            } // switch
        }
    }

} // namespace SharpTS.TypeScript.Types