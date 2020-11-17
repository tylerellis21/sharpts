namespace SharpTS.TypeScript.Types {

    /// <summary>
    /// This class represents a property in a typescript declaration
    /// </summary>
    public class TypeScriptProperty : TypeScriptType {

        /// <summary>
        /// True if the property is optional
        /// </summary>
        public bool Optional { get; set; } = false;

        /// <summary>
        /// The declared type of this property.
        /// </summary>
        /// <value></value>
        public TypeScriptType Type { get; set; }

        /// <summary>
        /// Construct an instance 
        /// </summary>
        /// <param name="name">The declared name of the property</param>
        /// <param name="type">The type of the declared property</param>
        public TypeScriptProperty(string name, TypeScriptType type) :
            base(name) {
            this.IsProperty = true;
            this.Type = type;
        }

    } // class TypeScriptProperty

} // namespace SharpTS.TypeScript.Types