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
    class SelfCompiler {

        private Regex Usings = new Regex(@"^using .*;",(RegexOptions.Multiline));
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
            var result = code_provider.CompileAssemblyFromSource(code_parameters, code);
            code_provider.Parse();
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
        public void AddUsingToSelfCompiler(string usings) {
            var matched_using = Usings.Matches(usings);
            foreach (Match item in matched_using) {
                var dll_name = item.Value.Replace("using", "").Replace(" ", "").Replace(";", ".dll");
                if (!ReferencedAssemblies.Contains(dll_name)) {
                    ReferencedAssemblies.Add(dll_name);
                }
            }
        }
        public SelfCompiler(){
            ReferencedAssemblies = new List<string>();
        }
    }
}