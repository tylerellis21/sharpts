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

        public void Translate(Type type) {
        }
    }

} // namespace SharpTS.TypeScript