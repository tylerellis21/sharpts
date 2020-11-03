using System;
using System.Text;
using System.Collections.Generic;

namespace SharpTS.TypeScript.Types {

    public class TypeScriptInterface : TypeScriptType { 
        
        public List<TypeScriptField> Fields { get; set; }

        public TypeScriptInterface(string name, List<TypeScriptField> fields) :
            base(name)
        { 
            this.Fields = fields;
        }

        public override string Generate() {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"interface {Name} {{");

            for (int i = 0; i < Fields.Count; i++) {
                TypeScriptField field = Fields[i];
                
                sb.Append("    ");
                sb.AppendLine($"    {Fields[i].Generate()}");
            }

            sb.AppendLine("}");

            return sb.ToString();
        }
 
    } // class TypeScriptInterface

} // namespace SharpTS.TypeScript.Types