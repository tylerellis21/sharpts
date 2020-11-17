using System;
using System.Collections.Generic;

using SharpTS.TypeConverters;

using SharpTS.TypeScript;
using SharpTS.TypeScript.Types;

namespace SharpTS.TypeConverters {

    public class ClassTypeConverter {

        public static TypeScriptClass Convert(Type type) {
            List<TypeScriptField> fields = null;
            TypeScriptClass result = new TypeScriptClass(type.Name, fields);

            return result;
        }

    } // class ClassTypeConverter

} // namespace SharpTS.TypeConverters