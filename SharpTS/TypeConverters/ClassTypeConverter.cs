using System;
using System.Collections.Generic;
using System.Reflection;

using SharpTS.TypeConverters;

using SharpTS.TypeScript;
using SharpTS.TypeScript.Types;

namespace SharpTS.TypeConverters {

    public partial class SharpTypeConverter {

        // It might be nice to also produce the attributes of the class in the typescript code as a comment

        /// <summary>
        /// Currently this method only translated properties into the typescript model
        /// We might change this in the future
        /// </summary>
        /// <param name="type">The type being translated to TypeScript</param>
        /// <returns>An instance of the TypeScriptClass or null if an error occurs</returns>
        public TypeScriptClass ConvertClass(Type type) {

            string name = type.Name;

            if (App.Project.PrefixInterfacesWithI) {
                name = "I" + name;
            }

            TypeScriptClass tsc = new TypeScriptClass(name);

            // TODO: Fields
            // Fields
            {

            }

            // Properties
            {
                PropertyInfo[] properties = type.GetProperties();

                foreach (PropertyInfo prop in properties) {

                    // Handle the self referencing by simply creating our own class with the proper reference.
                    if (prop.PropertyType.GUID == type.GUID) {
                        tsc.Properties.Add(new TypeScriptProperty(prop.Name, tsc));
                    }
                    else {
                        tsc.Properties.Add(ConvertProperty(prop));
                    }
                }
            }

            // Handle the class base type if it's not just System.Object
            tsc.BaseType = ConvertType(type.BaseType);

            // Handle any implemented interfaces
            {
                Type[] interfaces = type.GetInterfaces();
                foreach (Type iType in interfaces) {
                    tsc.ImplementedInterfaces.Add(ConvertType(iType));
                }
            }

            return tsc;
        }

    } // class ClassTypeConverter

} // namespace SharpTS.TypeConverters