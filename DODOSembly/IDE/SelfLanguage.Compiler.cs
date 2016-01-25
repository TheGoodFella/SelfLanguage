using System;
using System.Reflection;
using Microsoft.CSharp;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using SelfLanguage.Attributes;

namespace SelfLanguage.Compiler
{
    class Compiler {
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
        private const string RegexPropertyNameForCode = @"^(\t| )*((private | |const ))* *(string |String ) *[A-z\d]*";
		/// <summary>
		/// Regex for getting the property line of entryPoint
		/// </summary>
        private const string RegexPropertyNameForEntryPointOrMemory = @"^(\t| )*((private | |const ))* *(int |Int32 ) *[A-z\d]*";
		/// <summary>
		/// Regex for getting the method name of the Run, just 1 run per class is allowed
		/// </summary>
		private const string RegexMethodName = @"^(\t| )*((private | |void |public |static |abstract ))* *[A-z\d]*\(\){(\n)*}";
	#endregion

        public string StandardTemplatePath { get; set; }
        public string[] FoldersToAddForCompilation { get; set; }
        public Compiler(){}
        public Compiler(string standTemp, string[] fldToAdd) {
            StandardTemplatePath = standTemp;
            FoldersToAddForCompilation = fldToAdd;
        }
		//[SelfLanguage.Attributes.SelfProperty]
        public bool Compile(string output_path,string[] selfLanguage,string container) {
            List<string> Assemblyes= container.Replace("\r","").Split('\n').Where((s)=>s.IndexOf("using")!=-1).Select((w)=>w.Split(' ').ElementAt(1)).ToList();
            return false;
        }
        //https://msdn.microsoft.com/it-it/library/system.codedom.compiler.codedomprovider.compileassemblyfromsource(v=vs.110).aspx
        //private Assembly BuildAssembly(string code,string[] assembly) {
        //    CSharpCodeProvider provider = new CSharpCodeProvider();
        //    var parameters = new System.CodeDom.Compiler.CompilerParameters(assembly);
        //    Environment.SpecialFolder.
        //    return provider.CompileAssemblyFromSource(parameters, code).CompiledAssembly;
        //}
    }
}
