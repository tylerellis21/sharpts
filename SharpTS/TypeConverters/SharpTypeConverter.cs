using System;
using System.Collections.Generic;

using SharpTS.TypeConverters;

using SharpTS.TypeScript;
using SharpTS.TypeScript.Types;

namespace SharpTS.TypeConverters {

    /// <summary>
    /// This class is responsible for converting the C# types into the appropriate TypeScript type.
    /// </summary>
    public partial class SharpTypeConverter {

        /// <summary>
        /// The array of C# types that will be converted to typescript types.
        /// </summary>
        /// <value>The list of types to be converted</value>
        public List<Type> InputTypes { get; }

        private Dictionary<Guid, TypeScriptType> type_map;

        private List<Guid> processingTypes;

        /// <summary>
        /// Pass in the array of C# types that are being converted into typescript types.
        /// </summary>
        /// <param name="types">The list of types to be converted</param>
        public SharpTypeConverter(List<Type> types) {
            this.InputTypes = types;
            this.type_map = new Dictionary<Guid, TypeScriptType>();
            this.processingTypes = new List<Guid>();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool Convert() {
            foreach (Type type in InputTypes) {
                TypeScriptType tsType = ConvertType(type);
            }
            return true;
        }

        private TypeScriptType ConvertType(Type type) {

            if (type == null) return null;

            // ERROR: Hospital class contains fields of type Hospital
            // Self referencing classes cause a stack overflow from infinite recursion.

            Console.WriteLine($"converting type {type.FullName} {type.GUID}");

            // We don't want to convert types more than once so we map the converted ones
            // to their GUID
            if (type_map.ContainsKey(type.GUID)) {
                return type_map[type.GUID];
            }

            // Since we can't store an object in the type map until we fully resolve it
            // We will add it's GUID to a list so any type that trys to convert in a recursion call,
            // will be stopped.

            processingTypes.Add(type.GUID);

            TypeScriptType result = null;

            switch (type.FullName) {
                case "System.Decimal":
                case "System.String":
                case "System.DateTime":
                result = ConvertPrimitive(type);
                break;
            }

            if (type.IsPrimitive && result == null) {
                result = ConvertPrimitive(type);
            }
            else if (type.IsClass) {
                result = ConvertClass(type);
            }
            else if (type.IsInterface) {
                result = ConvertInterface(type);
            }
            else if (type.IsArray) {
                result = ConvertArray(type);
            }
            else if (type.IsEnum) {
                result = ConvertEnum(type);
            }

            if (result == null) {
                throw new Exception($"type failed to find converter: '{type.FullName}'");
            }

            Console.WriteLine($"mapped type '{type.FullName} {type.GUID}'");

            processingTypes.Remove(type.GUID);

            return result;
        }
        
    } // class SharpTypeConverter

} // namespace SharpTS.TypeConverters