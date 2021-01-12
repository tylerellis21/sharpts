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

        public List<TypeScriptType> MappedTypes { get; set; }

        private Dictionary<Guid, TypeScriptType> type_map;

        /// <summary>
        /// Pass in the array of C# types that are being converted into typescript types.
        /// </summary>
        /// <param name="types">The list of types to be converted</param>
        public SharpTypeConverter(List<Type> types) {
            this.InputTypes = types;
            this.type_map = new Dictionary<Guid, TypeScriptType>();
            this.MappedTypes = new List<TypeScriptType>();
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public bool Convert() {
            foreach (Type type in InputTypes) {
                TypeScriptType tsType = ConvertType(type);
                MappedTypes.Add(tsType);
            }
            return true;
        }

        private static List<string> ArrayTypes = new List<string>() {
            "System.Collections.ICollection"
        };

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

            TypeScriptType result = null;

            // Some weird edge cases
            {
                if (ArrayTypes.Contains(type.Name)) {
                    return ConvertArray(type);
                }
                // Technically not 'Primitives' but in TypeScript we are limited to very
                // few basic primatives
                switch (type.Name) {
                    case "Decimal":
                    case "String":
                    case "DateTime":
                    case "DateTimeOffset":
                        result = ConvertPrimitive(type);
                    break;
                }

                // The collection interface has weird name.
                // There's a bette way to handle this i'm sure.
                if (type.Name.StartsWith("ICollection")) {
                    result = ConvertICollection(type);
                }

                // Nullable types in dotnet are wrapped in a 'System.Nullable' type
                if (type.FullName.StartsWith("System.Nullable")) {
                    result = ConvertNullableProperty(type);
                }
            }

            // This following only executes as long as there is no
            // result set from the previous edge cases.
            if (result == null) {
                if (type.IsPrimitive) {
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
            }

            if (result == null) {
                throw new Exception($"type failed to find converter: '{type.FullName}'");
            }

            Console.WriteLine($"mapped type '{type.FullName} {type.GUID}'");

            return result;

        } // ConvertType

    } // class SharpTypeConverter

} // namespace SharpTS.TypeConverters