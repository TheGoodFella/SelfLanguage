using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SelfLanguage.Compiler;
using SelfLanguage.Attributes;

namespace IDE.ProjectTemplates {
    class ConsoleTemplate {
        [SelfPropertyAttributeEntryPoint]
        int programEntryPoint { get; set; }
        [SelfPropertyAttributeMemoryToAlloc]
        int programMemoryNeeded { get; set; }
        static void Main() {
            Run();
        }
        [SelfMethodAttributeRun]
        static void Run() {
            return;
        }
    }
}
