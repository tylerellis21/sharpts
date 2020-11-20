using System;
using System.Collections.Generic;
using System.Reflection;

using SharpTS.TypeConverters;

using SharpTS.TypeScript;
using SharpTS.TypeScript.Types;

namespace SharpTS.TypeConverters {

    public partial class SharpTypeConverter {
        
        public TypeScriptArray ConvertArray(Type type) {
            return null;
        }

        public TypeScriptArray ConvertICollection(Type type) {
            
            // (@Tyler) We are cheating atm with using an array of any but i would love to have arrays
            // properly typed.
            // Again this comes back to the problem of self referencing types. bahh...
            // We might need to build some sort of delayed resolution system.

            /*
            Type[] genericArgs = type.GetGenericArguments();

            TypeScriptType arrayType = ConvertType(genericArgs[0]);
            */

            // This isn't going to work.
            return new TypeScriptArray(
                "", new TypeScriptPrimitive(type.GetGenericArguments()[0].Name, TSPrimitiveType.TSAny)
            );
        }

    } // class SharpTypeConverter

} // namespace SharpTS.TypeConverters