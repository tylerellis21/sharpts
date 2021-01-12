using System;
using System.Text.RegularExpressions;

namespace SharpTS.Reflection {

    public class TypeRule {
        // If this is an include rule, we are searching for items that match the pattern
        // Otherwise it's an exclude and we add all types not matching the pattern.
        public bool Include { get; set; } = true;

        public bool EnableClassGeneration { get; set; } = true;
        public bool EnableEnumGeneration { get; set; } = true;
        public bool EnableInterfaceGeneration { get; set; } = true;

        public string Pattern { get; set; } = "";

        public bool Match(Type type) {

            if (type.IsClass && EnableClassGeneration == false)
                return false;

            if (type.IsEnum && EnableEnumGeneration == false)
                return false;

            if (type.IsInterface && EnableInterfaceGeneration == false)
                return false;

            return TypeRegex.RegexTestType(type, Pattern);
        }

    } // class TypeRule

} // namespace SharpTS.Reflection