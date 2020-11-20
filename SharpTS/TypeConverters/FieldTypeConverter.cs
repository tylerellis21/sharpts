using System;
using System.Collections.Generic;
using System.Reflection;

using SharpTS.TypeConverters;

using SharpTS.TypeScript;
using SharpTS.TypeScript.Types;

namespace SharpTS.TypeConverters {

    public partial class SharpTypeConverter {

       public TypeScriptField ConvertField(FieldInfo fieldInfo) {
           
           object value = fieldInfo.GetRawConstantValue();

           TypeScriptType tsType = null;
           return new TypeScriptField(fieldInfo.Name, value, tsType);
       } 

    } // class SharpTypeConverter

} // namespace SharpTS.TypeConverters