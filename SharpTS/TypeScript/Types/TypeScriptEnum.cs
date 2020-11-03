using System;
using System.Text;
using System.Collections.Generic;

namespace SharpTS.TypeScript.Types {

    public class TypeScriptEnum : TypeScriptType { 
        
        public List<TypeScriptField> Values { get; set; }

        public TypeScriptEnum(string name) :
            base(name)
        { }
        
        public TypeScriptEnum(string name, List<TypeScriptField> values) :
            base(name) { 
            this.Values = values;
        }

        public override string Generate() {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"enum {Name} {{");
            
            for (int i = 0; i < Values.Count; i++) {
                TypeScriptField field = Values[i];
                
                sb.Append("    ");
                sb.Append($"{field.Generate()}");

                if (i + 1 < Values.Count) sb.Append(",");

                sb.AppendLine();
            }

            sb.AppendLine("}");

            return sb.ToString();
        }
    } // class TypeScriptEnum
} // namespace SharpTS.TypeScript.Types