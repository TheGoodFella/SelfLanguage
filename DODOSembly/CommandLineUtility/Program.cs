using System;
using SelfLanguage;
using System.IO;

namespace CommandLineUtility {
    class Program {
        static string program = default(string);
        static void Main(string[] args) {
            foreach (var item in args) {
                if (Directory.Exists(item)) {
                    program = File.ReadAllText(item);
                }
            }
        }
    }
}