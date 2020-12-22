using System;
using System.Text.RegularExpressions;

namespace SharpTS.Reflection {

    public class TypeRule {

        public bool EnableClassGeneration { get; set; } = true;
        public bool EnableEnumGeneration { get; set; } = true;
        public bool EnableInterfaceGeneration { get; set; } = true;

        public string Pattern { get; set; } = "";

        public bool Pass(Type type) {

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