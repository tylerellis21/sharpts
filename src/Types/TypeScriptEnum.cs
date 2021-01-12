using System;
using System.Text;
using System.Collections.Generic;

namespace SharpTS.TypeScript.Types {

    public class TypeScriptEnum : TypeScriptType { 
        
        public List<TypeScriptField> Fields { get; set; }

        public TypeScriptEnum(string name) :
            base(name)
        { }
        
        public TypeScriptEnum(string name, List<TypeScriptField> fields) :
            base(name) { 
            this.IsEnum = true;
            this.Fields = fields;
        }

    } // class TypeScriptEnum
    
} // namespace SharpTS.TypeScript.Types