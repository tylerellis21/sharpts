using System;
using System.Collections.Generic;

namespace SharpTS.TypeScript.Types {
    public class TypeScriptMethod : TypeScriptType {
        public bool IsPrototype { get; set; }
        public TypeScriptType ReturnType { get; set; }
        public List<TypeScriptField> Arguments { get; set; }
        public TypeScriptMethod(string name, 
                List<TypeScriptField> arguments, 
                TypeScriptType returnType) :
            base(name) {
            this.IsMethod = true;
            this.Arguments = arguments;
            this.ReturnType = returnType;
        }

    } // class TypeScriptMethod

} // SharpTS.TypeScript.Types