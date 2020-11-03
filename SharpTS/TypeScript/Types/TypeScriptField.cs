using System;
using System.Text;

namespace SharpTS.TypeScript.Types {
    public class TypeScriptField : TypeScriptType { 

        public TypeScriptType Type { get; set; }

        public TypeScriptField(string name, TypeScriptType type) :
            base(name) {
            this.Type = type;
        }
        // Field is in the syntax of
        // name: Type;
        public override string Generate() => Type == null ? $"{Name}: " : $"{Name}: {Type.Generate()};";
        
    } // class TypeScriptField

} // namespace SharpTS.TypeScript.Types