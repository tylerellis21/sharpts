using System;
using System.Text.RegularExpressions;

namespace SharpTS.Reflection {

    public class TypeRules { 
        public bool EnableClasses { get; set; } = true;
        public bool EnableInterfaces { get; set; } = true;
        
        public bool EnableRegexFilter { get; set; } = false;
        public string RegexPattern { get; set; } = "";
    }

} // namespace SharpTS.Reflection