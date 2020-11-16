using System;
using System.IO;

namespace SharpTS.TypeScript.Types {

    public abstract class TypeScriptType {

        public string Name { get; set; }

        public TypeScriptType(string name) {
            this.Name = name;
        }
    }

} // SharpTS.TypeScript.Types