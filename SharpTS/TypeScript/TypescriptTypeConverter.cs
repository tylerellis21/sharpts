using System;
using System.Collections.Generic;

namespace SharpTS.TypeScript {
    /// <summary>
    /// This class is responsible for converting the C# types into the appropriate TypeScript type.
    /// </summary>
    public class SharpTypeConverter {

        /// <summary>
        /// The array of C# types that will be converted to typescript types.
        /// </summary>
        /// <value>The list of types to be converted</value>
        public List<Type> InputTypes { get; }

        /// <summary>
        /// Pass in the array of C# types that are being converted into typescript types.
        /// </summary>
        /// <param name="types">The list of types to be converted</param>
        public SharpTypeConverter(List<Type> types) {
            this.InputTypes = InputTypes;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Convert() {
            return true;
        }
        
    } // class SharpTypeConverter

} // namespace SharpTS.TypeScript