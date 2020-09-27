using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Diagnostics;

using SharpTS.TypeScript.Types;

namespace SharpTS.TypeScript {
    
    public class TypeScriptTypeTranslator {

        private Dictionary<Type, TypeScriptType> type_map;

        public TypeScriptTypeTranslator() {
            this.type_map = new Dictionary<Type, TypeScriptType>();
        }

        public TypeScriptType Translate(Type type) {
            
            if (type.IsInterface) return TranslateInterface(type);

            switch (type.FullName) {
            case "System.String": return new TypeScriptBasicType(type.Name, TSBasicType.TSString);
            }

            return null;
        }

        private TypeScriptInterface TranslateInterface(Type type) {

            List<TypeScriptField> ts_fields = new List<TypeScriptField>();
            
            //FieldInfo[] fields = type.GetFields();
            PropertyInfo[] properties = type.GetProperties();
            foreach(PropertyInfo property in properties) {
                ts_fields.Add(TranslateProperty(property));
            }
            //foreach (FieldInfo field in fields) {
            //    ts_fields.Add(TranslateField(field));
            //}

            return new TypeScriptInterface(type.Name, ts_fields);
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