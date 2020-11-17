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
            this.IsClass = true;
            this.Fields = fields;
        }

    } // class TypeScriptClass

} // namespace SharpTS.TypeScript.Types