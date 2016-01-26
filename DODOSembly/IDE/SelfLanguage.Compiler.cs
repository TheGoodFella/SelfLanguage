using Microsoft.CSharp;
using SelfLanguage.Attributes;
using System;
using System.Reflection;
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
        private Regex RegexPropertyForCode = new Regex(@"^(\t| )*((static |private | |const ))* *(string |String ) *[A-z\d]*");
		/// <summary>
		/// Regex for getting the property line of entryPoint
		/// </summary>
        private Regex RegexPropertyNameForEntryPointOrMemory = new Regex(@"^(\t| )*((static |private | |const ))* *(int |Int32 ) *[A-z\d]*");
		/// <summary>
		/// Regex for getting the method name of the Run, just 1 run per class is allowed
		/// </summary>
        private Regex RegexMethodName = new Regex(@"^(\t| )*((private | |void |public |static |abstract ))* *[A-z\d]*\(\){(\n)*}");
	#endregion

        public string StandardTemplatePath { get; set; }
        public string[] FoldersToAddForCompilation { get; set; }
        public SelfCompiler(){}
        public SelfCompiler(string standTemp, string[] fldToAdd) {
            StandardTemplatePath = standTemp;
            FoldersToAddForCompilation = fldToAdd;
        }
        public bool Compile(string output_path,string selfLanguage,string container) {
            // List<string> Assemblyes= container.Replace("\r","").Split('\n').Where((s)=>s.IndexOf("using")!=-1).Select((w)=>w.Split(' ').ElementAt(1)).ToList();
            var containerArray = container.Replace("\r","").Split('\n');
            var tmpSplit = selfLanguage.Replace("\r", "").Split('\n');
            if (tmpSplit[0].IndexOf('#') != -1 && tmpSplit[1].IndexOf('#') != -1) {
                var entry = Convert.ToInt32(tmpSplit[0].Split('=')[1]);
                var memory = Convert.ToInt32(tmpSplit[1].Split('=')[1]);
                var entryVariableName = "";
                var memoryVariableName = "";
                selfLanguage = selfLanguage.Replace(tmpSplit[0], "").Replace(tmpSplit[1], "").Replace("\r","").Replace("\n","");
                for (var i = 0; i < containerArray.Length; ) {
                    if (containerArray[i++].Contains(SelfLanguageEntrypoint)) {
                        var regex_extracted = RegexPropertyNameForEntryPointOrMemory.Match(containerArray[i]).Value;
                        containerArray[i]=containerArray[i].Replace(regex_extracted, regex_extracted + "=" + entry);
                        entryVariableName = regex_extracted.Split(' ').Last();
                        i = containerArray.Length;
                    }
                }
                for (var i = 0; i < containerArray.Length; ) {
                    if (containerArray[i++].Contains(SelfLanguageMemory)) {
                        var regex_extracted = RegexPropertyNameForEntryPointOrMemory.Match(containerArray[i]).Value;
                        containerArray[i] = containerArray[i].Replace(regex_extracted, regex_extracted + "=" + memory);
                        memoryVariableName = regex_extracted.Split(' ').Last();
                        i = containerArray.Length;
                    }
                }
                for (var i = 0; i < containerArray.Length;) {
                    if (containerArray[i++].Contains(SelfLanguageCode)) {
                        var regex_ext = RegexPropertyForCode.Match(containerArray[i]).Value;
                        containerArray[i] = containerArray[i].Replace(regex_ext, string.Format(regex_ext, selfLanguage));
                        i = containerArray.Length;
                    }
                }
                var cec= new CompilerErrorCollection();
                var result = BuildAssembly(containerArray.ToList().Aggregate((s1, s2) => s1 + s2), output_path, out cec);
                foreach (var item in cec) {
                    System.Windows.Forms.MessageBox.Show(item.ToString());
                }
                return result;
            } else {
                return false;
            }
        }
        
        private bool BuildAssembly(string code, string path, out CompilerErrorCollection Errors) {
            CSharpCodeProvider provider = new CSharpCodeProvider(new Dictionary<string, string> {{"CompilerVersion","v4.0"}});
            var executionAssembly = Assembly.GetExecutingAssembly();
            var parameters = new CompilerParameters { GenerateExecutable = true,GenerateInMemory=true, OutputAssembly = path};
            parameters.ReferencedAssemblies.AddRange(new string[]{"System.dll","mscorlib.dll","System.Data.dll","System.Core.dll",executionAssembly.Location});
            parameters.TreatWarningsAsErrors = false;
            parameters.CompilerOptions = "/optimize";
            var v = provider.CompileAssemblyFromSource(parameters, code);
            Errors = v.Errors;
            return v.Errors.Count > 0 ? false : true; //More than 0 errors? return false
        }
    }
}