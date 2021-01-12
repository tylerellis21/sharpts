using SharpTS.Reflection;
using SharpTS.TypeScript;
using SharpTS.TypeScript.Types;

using SharpTS.TypeConverters;
using SharpTS.SourceGenerators;

namespace SharpTS {

    public class ProjectFile {

        public string[] InputAssemblies { get; set; }

        public string OutputDirectory { get; set; } = "./";

        public TypeRule[] Rules { get; set; }

        public bool PrefixInterfacesWithI { get; set; } = true;
    }

} // namespace SharpTS