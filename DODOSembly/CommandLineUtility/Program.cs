using System;
using SelfLanguage;
using System.IO;
using System.Reflection;
using System.Linq;

namespace CommandLineUtility {
    class Program {
        static string program = default(string);
        static void Main(string[] args) {
            var ass = typeof(Language).Assembly;
            Console.WriteLine(ass.GetReferencedAssemblies().Select(s=>s.Name).Aggregate((l,k)=>l+"\n"+k));
            Console.ReadLine();
        }
    }
}