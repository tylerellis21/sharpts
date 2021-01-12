using System;
using System.IO;

namespace SharpTS.TypeScript.Types {

    /// <summary>
    /// The base class for all TypeScript Types.
    /// The base class contains only the name definition of the declared type.
    /// </summary>
    public abstract class TypeScriptType {
        
        public bool IsArray { get; set; } = false;

        public bool IsPrimitive { get; set; } = false;

        public bool IsClass { get; set; } = false;

        public bool IsEnum { get; set; } = false;

        public bool IsField { get; set; } = false;

        public bool IsInterface { get; set; } = false;

        public bool IsProperty { get; set; } = false;

        public bool IsMethod { get; set; } = false;

        /// <summary>The name of the declared type.</summary>
        public string Name { get; set; }

        /// <summary>
        /// Create an instance of a given type with a name.
        /// </summary>
        /// <param name="name">The declaration type name</param>
        public TypeScriptType(string name) {
            this.Name = name;
        }
        
    } // class TypeScriptType

} // namespace SharpTS.TypeScript.Types