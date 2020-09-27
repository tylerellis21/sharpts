using System;
using System.Collections.Generic;

namespace SharpTS.TypeScript.Types {

    public class TypeScriptInterface : TypeScriptType { 
        
        public List<TypeScriptField> Fields { get; set; }

        public TypeScriptInterface(string name, List<TypeScriptField> fields) :
            base(name)
        { 
            this.Fields = fields;
        }
    }

} // namespace SharpTS.TypeScript.Types