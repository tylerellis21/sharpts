using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Diagnostics;

namespace SharpTS.Reflection {

    public static class TypeReflection {

        // 
        public static List<Type> LoadTypes(
            ref List<string> input_assemblies, 
            ref List<string> input_namespaces) {

            List<Type> types = new List<Type>();

            return types;
        }
   /*
        static List<Type> SearchNamespaceType(Assembly assembly, string name) {
            List<Type> types = new List<Type>();

            Type[] assembly_types = assembly.GetTypes();

            foreach (Type type in assembly_types) {
                Console.WriteLine($"{type.Attributes} {type.FullName}");
            }

            return types;
        }
*/
    } // class TypeReflection
    
} // namespace SharpTS.Reflection
 