using System;
using System.Text.RegularExpressions;

namespace SharpTS.Reflection {

    public class TypeRules { 

        public bool EnableClasses { get; set; } = true;
        public bool EnableInterfaces { get; set; } = true;
        public bool EnableEnums { get; set; } = true;
        
        public bool EnableRegexFilter { get; set; } = false;
        public string RegexPattern { get; set; } = "";

        // Test a type against the currently defined rule.
        public bool Check(Type type) {

            if (type.IsClass && EnableClasses == false) 
                return false;

            if (type.IsEnum && EnableEnums == false) 
                return false;

            if (type.IsInterface && EnableInterfaces == false)
                return false;

            if (EnableRegexFilter) {
                return TypeRegex.RegexTestType(type, RegexPattern);
            }
            
            return true;
        }
    }

} // namespace SharpTS.Reflection