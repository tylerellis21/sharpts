using System;
using System.Collections.Generic;
using System.Reflection;

using SharpTS.TypeConverters;

using SharpTS.TypeScript;
using SharpTS.TypeScript.Types;

namespace SharpTS.TypeConverters {

    public partial class SharpTypeConverter {

        public TypeScriptProperty ConvertProperty(PropertyInfo propInfo) 
            => new TypeScriptProperty(propInfo.Name, ConvertType(propInfo.PropertyType));

    } // class SharpTypeConverter

} // namespace SharpTS.TypeConverters