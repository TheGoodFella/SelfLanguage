using Microsoft.CSharp;
using SelfLanguage.Attributes;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SelfLanguage.Compiler
{
    class SelfCompiler {
        #region Property name and regex
        /// <summary>
		/// The code property must have this attribute 
		/// </summary>
        public readonly string SelfLanguageCode = string.Format("[{0}]",typeof(SelfPropertyAttributeCode).Name);
		/// <summary>
		/// The Entrypoint must have this attribute 
        /// </summary>
        public readonly string SelfLanguageEntrypoint = string.Format("[{0}]", typeof(SelfPropertyAttributeEntryPoint).Name);
        /// <summary>
        /// The Memory property must have this attribute 
        /// </summary>
        public readonly string SelfLanguageMemory = string.Format("[{0}]", typeof(SelfPropertyAttributeMemoryToAlloc).Name);
		/// <summary>
		/// The Run method must have this attribute 
		/// </summary>
        public readonly string RunMethod = string.Format("[{0}]", typeof(SelfMethodAttributeRun).Name);
		/// <summary>
		/// Regex for getting the property line of the string Code property
		/// </summary>
        private const Regex RegexPropertyForCode = new Regex(@"^(\t| )*((private | |const ))* *(string |String ) *[A-z\d]*");
		/// <summary>
		/// Regex for getting the property line of entryPoint
		/// </summary>
        private const Regex RegexPropertyNameForEntryPointOrMemory = new Regex(@"^(\t| )*((private | |const ))* *(int |Int32 ) *[A-z\d]*");
		/// <summary>
		/// Regex for getting the method name of the Run, just 1 run per class is allowed
		/// </summary>
        private const Regex RegexMethodName = new Regex(@"^(\t| )*((private | |void |public |static |abstract ))* *[A-z\d]*\(\){(\n)*}");
	#endregion

        public string StandardTemplatePath { get; set; }
        public string[] FoldersToAddForCompilation { get; set; }
        public SelfCompiler(){}
        public SelfCompiler(string standTemp, string[] fldToAdd) {
            StandardTemplatePath = standTemp;
            FoldersToAddForCompilation = fldToAdd;
        }
        public bool Compile(string output_path,string[] selfLanguage,string container) {
            // List<string> Assemblyes= container.Replace("\r","").Split('\n').Where((s)=>s.IndexOf("using")!=-1).Select((w)=>w.Split(' ').ElementAt(1)).ToList();
            selfLanguage = selfLanguage.ToList().Where((s) => s.Replace(" ", "").Replace("\t", "").Length != 0).ToArray();
     
            if (selfLanguage[0].IndexOf('#') != -1 && selfLanguage[1].IndexOf('#') != -1) {
                var entry = Convert.ToInt32(selfLanguage[0].Split('=')[1]);
                var memory = Convert.ToInt32(selfLanguage[1].Split('=')[1]);
                var toCompile = new List<string>();
                for (var i = 2; i < selfLanguage.Length; i++) {
                    if (selfLanguage[i].Contains(SelfLanguageEntrypoint)) {
                        var regex_extracted = RegexPropertyNameForEntryPointOrMemory.Match(selfLanguage[i++]).Value;
                        selfLanguage[i].Replace(regex_extracted, regex_extracted + "=" + entry);
                        i = selfLanguage.Length;
                    }
                }
                for (var i = 2; i < selfLanguage.Length; i++) {
                    if (selfLanguage[i].Contains(SelfLanguageMemory)) {
                        var regex_extracted = RegexPropertyNameForEntryPointOrMemory.Match(selfLanguage[i++]).Value;
                        selfLanguage[i].Replace(regex_extracted, regex_extracted + "=" + memory);
                    }
                }
                var cec= new CompilerErrorCollection();
                BuildAssembly(selfLanguage.ToList().Aggregate((s1, s2) => s1 + s2), output_path, out cec);
                return true;
            } else {
                return false;
            }
        }
        //https://msdn.microsoft.com/it-it/library/system.codedom.compiler.codedomprovider.compileassemblyfromsource(v=vs.110).aspx
        private bool BuildAssembly(string code, string path, out CompilerErrorCollection Errors) {
            CSharpCodeProvider provider = new CSharpCodeProvider();
            var parameters = new CompilerParameters { GenerateExecutable = true, OutputAssembly = path};
            var v = provider.CompileAssemblyFromSource(parameters, code);
            Errors = v.Errors;
            return v.Errors.Count > 0 ? false : true; //More than 0 errors? return false
        }
    }
}
