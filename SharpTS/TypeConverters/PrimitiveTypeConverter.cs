using System;
using System.Collections.Generic;
using System.Reflection;

using SharpTS.TypeConverters;

using SharpTS.TypeScript;
using SharpTS.TypeScript.Types;

namespace SharpTS.TypeConverters {

    public partial class SharpTypeConverter {

        public TypeScriptPrimitive ConvertPrimitive(Type type) {

            TSPrimitiveType tspType;

            switch (type.FullName) {
                
                case "System.Boolean":
                    tspType = TSPrimitiveType.TSBoolean;
                break;

                case "System.Int8":
                case "System.Int16":
                case "System.Int32":
                case "System.Int64": 
                case "System.UInt8":
                case "System.UInt16":
                case "System.UInt32":
                case "System.UInt64": 
                case "System.Double": 
                case "System.Decimal": 
                    tspType = TSPrimitiveType.TSNumber; 
                break;

                case "System.Char": 
                case "System.String": 
                    tspType = TSPrimitiveType.TSString; 
                break;
                
                case "System.Date":
                    tspType = TSPrimitiveType.TSDate;
                break;


                case "System.Object":
                    tspType = TSPrimitiveType.TSAny;
                break;

                default: tspType = TSPrimitiveType.TSNull; break;
                
            } // switch (type.FullName)

            return new TypeScriptPrimitive(type.Name, tspType);
        }

    } // class SharpTypeConverter

} // namespace SharpTS.TypeConverters