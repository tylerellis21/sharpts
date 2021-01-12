using System;
using System.Text;
using System.Collections.Generic;

namespace SharpTS.TypeScript.Types {

    public class TypeScriptClass : TypeScriptType { 
        public TypeScriptType BaseType { get; set; } = null;
        public List<TypeScriptType> ImplementedInterfaces { get; set; } = new List<TypeScriptType>();
        public List<TypeScriptField> Fields { get; set; } = new List<TypeScriptField>();
        public List<TypeScriptProperty> Properties { get; set; } = new List<TypeScriptProperty>();

        public TypeScriptClass(string name) :
            base(name) {
            this.IsClass = true;
        }        

        public TypeScriptClass(string name,
            TypeScriptType baseType,
            List<TypeScriptType> implementedInterfaces,
            List<TypeScriptField> fields, 
            List<TypeScriptProperty> properties) :
            base(name) { 
            this.IsClass = true;
            this.BaseType = baseType;
            this.ImplementedInterfaces = implementedInterfaces;
            this.Fields = fields;
            this.Properties = properties;
        }

    } // class TypeScriptClass

} // namespace SharpTS.TypeScript.Types