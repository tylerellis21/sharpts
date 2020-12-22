using System;
using System.IO;
using System.Collections.Generic;

using Newtonsoft.Json;

using SharpTS.Utils;

namespace SharpTS.Utils {

    public static class ConfigFile {

        public static bool Load<T>(string path, out T value) where T : new() {
            if (File.Exists(path) == false) {
                Logger.Error($"reverting to default config settings, failed to load: {path}");
                value = new T();
                return true;
            }
            try {
                value =  JsonConvert.DeserializeObject<T>(File.ReadAllText(path));
                Logger.Info($"loaded config file: {path}");
                return true;
            }
            catch (Exception e) {
                value = new T();
                Logger.Error($"an exception occured trying to load file: {path}");
                Logger.Error($"exception: {e.Message}");
                return false;
            }
        }

        public static bool Save(string path, object obj) {
            try {
                File.WriteAllText(path, JsonConvert.SerializeObject(obj, Formatting.Indented));
                return true;
            }
            catch(Exception e) {
                Logger.Info($"failed to write file: {path}");
                Logger.Error($"exception: {e.Message}");
                return false;
            }
        }

    } // class ConfigFile

} // namespace SharpTS