using System;
using System.Text;
using System.Collections.Generic;

namespace SharpTS.TypeScript.Types {

    /// <summary>
    /// This class represents a TypeScript Interface
    /// </summary>
    public class TypeScriptInterface : TypeScriptType { 

        /// <summary>The list of declared properties in the interface</summary>
        public List<TypeScriptProperty> Properties { get; set; }
        
        /// <summary>
        /// Construct an instance of a typescript interface type
        /// </summary>
        /// <param name="name">The name of the declared type</param>
        /// <param name="properties">The declared properties in the interface</param>
        public TypeScriptInterface(string name, List<TypeScriptProperty> properties) :
            base(name) { 
            this.IsInterface = true;
            this.Properties = properties;
        }
 
    } // class TypeScriptInterface

} // namespace SharpTS.TypeScript.Types