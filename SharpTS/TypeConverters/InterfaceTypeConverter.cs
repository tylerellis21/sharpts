using System;
using System.Collections.Generic;
using System.Reflection;

using SharpTS.TypeConverters;

using SharpTS.TypeScript;
using SharpTS.TypeScript.Types;

namespace SharpTS.TypeConverters {

    public partial class SharpTypeConverter {
    
        public TypeScriptInterface ConvertInterface(Type type) {
            List<TypeScriptProperty> tsProps = new List<TypeScriptProperty>();
            PropertyInfo[] properties = type.GetProperties();
            foreach (PropertyInfo prop in properties) {
               tsProps.Add(ConvertProperty(prop)); 
            }
            return new TypeScriptInterface(type.Name, tsProps);
        }

    } // class SharpTypeConverter

} // namespace SharpTS.TypeConverters