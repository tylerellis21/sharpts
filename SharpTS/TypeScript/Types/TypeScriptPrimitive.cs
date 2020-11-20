using System;

namespace SharpTS.TypeScript.Types {
    public class TypeScriptPrimitive : TypeScriptType {

        public TSPrimitiveType Type { get; set; }

        public TypeScriptPrimitive(string name, TSPrimitiveType type) :
            base(name) {
            this.IsPrimitive = true;
            this.Type = type;
        }

    } // class TypeScriptPrimitiveType

} // namespace SharpTS.TypeScript.Types