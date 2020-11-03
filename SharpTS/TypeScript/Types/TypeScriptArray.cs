using System;
using System.IO;

namespace SharpTS.TypeScript.Types {

    public class TypeScriptArray : TypeScriptType { 
        
        public TypeScriptType Type { get; set; }

        public TypeScriptArray(string name, TypeScriptType type) :
            base(name) {
            this.Type = type;
        }

        // a: Array<T>

        public override string Generate() 
            => $"{Name}: Array<{Type.Generate()}>";

    } // class TypeScriptArray

} // namespace SharpTS.TypeScript.Types