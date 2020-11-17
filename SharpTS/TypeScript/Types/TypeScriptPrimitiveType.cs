using System;

namespace SharpTS.TypeScript.Types {
    public class TypeScriptPrimitiveType : TypeScriptType {

        public TSPrimitiveType Type { get; set; }

        public TypeScriptPrimitiveType(string name, TSPrimitiveType type) :
            base(name) {
            this.IsPrimitive = true;
            this.Type = type;
        }

    } // class TypeScriptPrimitiveType

} // namespace SharpTS.TypeScript.Types