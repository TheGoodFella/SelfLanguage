using System;
using SelfLanguage;
using System.IO;
using System.Reflection;
using System.Linq;

namespace CommandLineUtility {
    class Program {
        static ConsoleColor[] cll = { ConsoleColor.Red, ConsoleColor.Black, ConsoleColor.White };
        static void Main(string[] args) {
            string s = "rrbbrr0bbrrbb0rrbbrr";
            var lang = new Language(1024);
            lang.LoadInMemory("\0i&0\0j&38\0i&1\0j&38\0i&2\0j&38\0i&3\0j&38\0\\\0m&R:c::int;-\0j&20;=(chr|^r|R:c::int)\0j&20;=(chr|^b|R:c::int)\0j&18;=(chr|^w|R:c::int)\0j&0;=(chr|^0|R:c::int)\0\\p", 0);
            s.ToList().ForEach(a => lang.CommandStackCarry.Push(Convert.ToChar(a)));
            lang.DefineInterrupt(() => { Console.BackgroundColor = cll[0]; Console.Write(" "); }, 0);
            lang.DefineInterrupt(() => { Console.BackgroundColor = cll[1]; Console.Write(" "); }, 1);
            lang.DefineInterrupt(() => { Console.BackgroundColor = cll[2]; Console.Write(" "); }, 2);
            lang.DefineInterrupt(() => { Console.BackgroundColor = ConsoleColor.Black; Console.Write("\n"); }, 3);
            lang.Run(38);
            Console.ReadLine();
        }
    }
}