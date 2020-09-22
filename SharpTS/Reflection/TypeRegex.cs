using System;
using System.Text.RegularExpressions;

namespace SharpTS.Reflection {
    
    public static class TypeRegex { 

        public static bool RegexTestType(Type type, string pattern) {
            
            string type_name = type.FullName;

            // Find matches.
            MatchCollection matches = Regex.Matches(type_name, pattern);

            return matches.Count > 0;
        } // void RegexTestType 

    } // class TypeRegex

} // namespace SharpTS.Reflection