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

    } // class TypeScriptEnum
    
} // namespace SharpTS.TypeScript.Types