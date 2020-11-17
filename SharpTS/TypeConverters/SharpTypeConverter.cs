using System;
using System.Collections.Generic;

using SharpTS.TypeConverters;

using SharpTS.TypeScript;
using SharpTS.TypeScript.Types;

namespace SharpTS.TypeConverters {

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
            this.InputTypes = types;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Convert() {
            foreach (Type type in InputTypes) {
                Console.WriteLine($"converting type: {type.FullName} ");
                TypeScriptType tsType = ConvertType(type);
            }
            return true;
        }

        private TypeScriptType ConvertType(Type type) {
            if (type.IsClass) return ClassTypeConverter.Convert(type);
            
            throw new Exception($"type failed to find converter: '{type.FullName}'");
            return null;
        }
        
    } // class SharpTypeConverter

} // namespace SharpTS.TypeConverters