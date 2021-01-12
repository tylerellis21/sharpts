using System;
using System.Collections.Generic;
using System.Text;

namespace SharpTS.Utils {

    // TODO(@Tyler): Create a shared library for this and the config file.

    public class Logger {

        public enum Level {
            None = 0,
            Info = 1,
            Warning = 2,
            Error = 3
        }

        public static Level LogLevel = Logger.Level.None;

        public static void Log(Level level, string message, params object[] args) {
            if (level < LogLevel) return;

            ConsoleColor lastBG = Console.BackgroundColor;
            ConsoleColor lastFG = Console.ForegroundColor;

            switch (level) {

            default:
            case Level.None:
                Console.ForegroundColor = ConsoleColor.Gray;
            break;

            case Level.Info:
                Console.ForegroundColor = ConsoleColor.Green;
            break;

            case Level.Warning:
                Console.ForegroundColor = ConsoleColor.Yellow;
            break;

            case Level.Error:
                Console.ForegroundColor = ConsoleColor.Red;
            break;

            }

            if (args == null || args.Length == 0) {
                Console.WriteLine("{0} [{1}] {2}", DateTime.Now, level.ToString(), message);
            }
            else {
                Console.WriteLine("{0} [{1}] {2}", DateTime.Now, level.ToString(), string.Format(message, args));
            }

            Console.BackgroundColor = lastBG;
            Console.ForegroundColor = lastFG;
        }

        public static void Write(string message, params object[] args) => Log(Level.None, message, args);
        public static void Info(string message, params object[] args) => Log(Level.Info, message, args);
        public static void Warn(string message, params object[] args) => Log(Level.Warning, message, args);
        public static void Error(string message, params object[] args) => Log(Level.Error, message, args);

    } // class Logger

} // namespace SharpTS.Utils
