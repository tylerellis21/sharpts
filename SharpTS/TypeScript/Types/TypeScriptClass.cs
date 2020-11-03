using System;
using System.Text;
using System.Collections.Generic;

namespace SharpTS.TypeScript.Types {

    public class TypeScriptClass : TypeScriptType { 

        public TypeScriptType BaseType { get; set; } = null;

        public List<TypeScriptType> ImplementedInterfaces { get; set; } = new List<TypeScriptType>();

        public List<TypeScriptField> Fields { get; set; } = new List<TypeScriptField>();

        public TypeScriptClass(string name, List<TypeScriptField> fields) :
            base(name) { 
            this.Fields = fields;
        }
        
        /* Typescript Class Syntax: 
        class NAME extends BASE implements InterfaceA, InterfaceB {
            FIELD: TYPE;
        }
        */

        public override string Generate() {
            StringBuilder sb = new StringBuilder();
            // There can only be one BaseType which the class extends from
            //  
            sb.AppendLine($"class {Name} ");

            // If we have no fields we only generate the class name
            if (Fields == null || Fields.Count == 0) {
                return sb.ToString();
            }

            if (BaseType != null) {
                sb.AppendLine($"extends {BaseType.Name} ");
            }

            if (ImplementedInterfaces.Count > 0) {
                sb.Append($"implements ");
                for (int i = 0; i < ImplementedInterfaces.Count; i++) {
                    TypeScriptType interface_type = ImplementedInterfaces[i];
                    sb.Append($"{interface_type.Name}");
                    if (i + 1 < ImplementedInterfaces.Count) 
                        sb.Append(",");
                }
            }

            sb.AppendLine($" {{");

            for (int i = 0; i < Fields.Count; i++) {
                sb.AppendLine($" {Fields[i].Generate()}");
            }

            sb.AppendLine("}");

            return sb.ToString();
        }

    } // class TypeScriptClass

} // namespace SharpTS.TypeScript.Types