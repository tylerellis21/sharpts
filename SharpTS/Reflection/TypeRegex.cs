using System;
using System.Text.RegularExpressions;

namespace SharpTS.Reflection {
    
    public static class TypeRegex { 

        public static bool RegexTestType(Type type, string pattern)
            => Regex.Matches(type.FullName, pattern).Count > 0;
        
    } // class TypeRegex

} // namespace SharpTS.Reflection