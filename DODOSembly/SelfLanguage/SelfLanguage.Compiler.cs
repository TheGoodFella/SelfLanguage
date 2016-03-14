using Microsoft.CSharp;
using SelfLanguage.Attributes;
using System;
using System.Reflection;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using SelfLanguage.Utility;
using System.IO;

namespace SelfLanguage.Compiler {
    /// <summary>
    /// Compiler class
    /// </summary>
    public class SelfCompiler {
        /// <summary>
        /// All Assembly needed to compile the given code
        /// </summary>
        public List<string> ReferencedAssemblies { get; set; }
        /// <summary>
        /// On failed compilation, this event is rised
        /// </summary>
        public event EventHandler<Logging> OnFail;
        /// <summary>
        /// Compile an Assembly from the given sources
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public Assembly Compile(string[] code) {
            var code_provider = new CSharpCodeProvider();
            var code_parameters = new CompilerParameters();
            code_parameters.ReferencedAssemblies.AddRange(ReferencedAssemblies.ToArray());
            code_parameters.GenerateExecutable = false;
            code_parameters.GenerateInMemory = false;
            code_parameters.MainClass = "ConsoleTmp";
            var result = code_provider.CompileAssemblyFromSource(code_parameters, code);
            if (result.Errors.HasErrors) {
                foreach (var item in result.Errors) {
                    OnFail.Invoke(this, new Logging(item.ToString()));
                }
                return null;
            }
            return result.CompiledAssembly;
        }
        /// <summary>
        /// This addes all needed usings to the SelfCompiler. It does not duplicate them by default
        /// </summary>
        public void AddUsingToSelfCompiler(Assembly ass){
            ReferencedAssemblies.AddRange(ass.GetReferencedAssemblies().Select(s => s.Name.Trim() + ".dll").Where(s => !ReferencedAssemblies.Contains(s)));
        }
        public SelfCompiler(){
            ReferencedAssemblies = new List<string>();
        }
    }
}