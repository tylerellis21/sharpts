using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Diagnostics;

using SharpTS.TypeScript.Types;

namespace SharpTS.TypeScript {
    
    public class TypeScriptTypeTranslator {

        private Dictionary<Type, TypeScriptType> typeMap;  

        private List<TypeScriptType> tsTypes;

        public TypeScriptTypeTranslator() {
            typeMap = new Dictionary<Type, TypeScriptType>();  
            tsTypes = new List<TypeScriptType>();
        }

        public List<TypeScriptType> Translate(List<Type> types) {
            
            foreach (Type type in types) {

                if (typeMap.ContainsKey(type)) {
                    Console.WriteLine($"type already translated '{type.FullName}'");
                }
                else {
                    TypeScriptType tsType = Translate(type);
                    tsTypes.Add(tsType);
                    typeMap.Add(type, tsType);
                    Console.WriteLine($"translated type '{type.FullName}' -> '{tsType.Name}'");
                }
            }

            return tsTypes;
        }

        public TypeScriptType Translate(Type type) {
            
            switch (type.FullName) {
            case "System.Boolean":
                return new TypeScriptBasicType(type.Name, TSBasicType.TSBoolean);

            case "System.Char": 
            case "System.String": 
                return new TypeScriptBasicType(type.Name, TSBasicType.TSString);

            case "System.Int8":
            case "System.Int16":
            case "System.Int32":
            case "System.Int64":
            case "System.UInt8":
            case "System.UInt16":
            case "System.UInt32":
            case "System.UInt64":
            case "System.Decimal":
                return new TypeScriptBasicType(type.Name, TSBasicType.TSNumber);
            
            case "System.DateTime":
                return new TypeScriptClass("Date", null);

            default: break;
            } // switch 

            if (type.IsInterface) return TranslateInterface(type);
            if (type.IsClass) return TranslateClass(type);
            if (type.IsEnum) return TranslateEnum(type);

            throw new Exception("Unhandled typescript type");
            return null;
        }

        private TypeScriptInterface TranslateInterface(Type type) {

            List<TypeScriptField> ts_fields = new List<TypeScriptField>();
            
            PropertyInfo[] properties = type.GetProperties();

            foreach(PropertyInfo property in properties) {
                ts_fields.Add(TranslateProperty(property));
            }

            return new TypeScriptInterface(type.Name, ts_fields);
        }

        private TypeScriptClass TranslateClass(Type type) {

            List<TypeScriptField> ts_fields = new List<TypeScriptField>();
            
            PropertyInfo[] properties = type.GetProperties();

            foreach(PropertyInfo property in properties) {
                ts_fields.Add(TranslateField(property.PropertyType));
            }

            TypeScriptClass result 
                = new TypeScriptClass(type.Name, ts_fields);
            
            // if the type has a 'BaseType' then we must translate 
            //if (type.BaseType != null)
            //    result.BaseType = Translate(type.BaseType);

            Type[] interfaces = type.GetInterfaces();

            foreach (Type itype in interfaces) {
                result.ImplementedInterfaces.Add(Translate(itype));
            }
                
            return result;
        }
        
        private TypeScriptEnum TranslateEnum(Type type) {

            List<TypeScriptField> ts_values = new List<TypeScriptField>();
            
            string[] values = type.GetEnumNames();
            foreach (string value in values) {
                ts_values.Add(new TypeScriptField(value, null));
            }
            return new TypeScriptEnum(type.Name, ts_values);
        }

        private TypeScriptField TranslateField(FieldInfo field) {
            Type field_type = field.FieldType;
            TypeScriptType ts_type = Translate(field_type);
            return new TypeScriptField(field.Name, ts_type);
        }

        private TypeScriptField TranslateProperty(PropertyInfo property) {
            TypeScriptType ts_type = Translate(property.PropertyType);
            return new TypeScriptField(property.Name, ts_type);
        }

    } // class TypeScriptTypeTranslator

} // namespace SharpTS.TypeScript