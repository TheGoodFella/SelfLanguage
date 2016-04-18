using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SelfLanguage.Attributes;
using SelfLanguage;

namespace ConsoleTMP{
    class ConsoleTmp
    {
        static int Ent;
        static int Memory;

        static void Main()
        {
            Run();
        }
        static void Run()
        {
            var l = new Language(Memory);
            l.GenericLog = (s) => Console.WriteLine(s);
            l.Debug = (k) => { };
            l.LoadInMemory("{0}", 0);
            l.Run(Ent);
        }
    }
}