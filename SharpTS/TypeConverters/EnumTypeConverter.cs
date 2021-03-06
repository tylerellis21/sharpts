using System;
using System.Collections.Generic;
using System.Reflection;

using SharpTS.TypeConverters;

using SharpTS.TypeScript;
using SharpTS.TypeScript.Types;

namespace SharpTS.TypeConverters {

    public partial class SharpTypeConverter {
        
        public TypeScriptEnum ConvertEnum(Type type) {
            List<TypeScriptField> tsFields = new List<TypeScriptField>();
            {
                FieldInfo[] fields = type.GetFields();
                foreach (FieldInfo field in fields) {
                    
                    // I'm not sure where this is coming from but it's in there lol
                    if (field.Name == "value__") continue;

                    tsFields.Add(ConvertField(field));
                }
            }
            return new TypeScriptEnum(type.Name, tsFields);
        }

    } // class SharpTypeConverter

} // namespace SharpTS.TypeConverters