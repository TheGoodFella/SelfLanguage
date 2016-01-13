﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;
using SelfLanguage;

namespace DebugSelfLanguage {
    class Program {
        static void Main(string[] args) {
            var l = new Language(200);
            //l.LoadInMemory("\0s&72\0n\0s&69\0n\0s&76\0n\0s&76\0n\0s&79\0n\0s&32\0n\0s&87\0n\0s&79\0n\0s&82\0n\0s&68\0n\0s&10\0n\0\\", 0);
            l.LoadInMemory("\0m&10;6\0", 0);
            l.DefineInterrupt(() => { }, 0);
            l.GenericLog = ((s)=>Console.Write(s.Message));
            l.Run(0);
            Console.ReadLine();
        }
    }
}
