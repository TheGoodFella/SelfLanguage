using System;

namespace SelfLanguage.Compiler
{
    class Compiler
    {
        public static const string PutHereSelfLanguage = "[SelfLanguage.Attributes.SelfProperty]";
        private static const string RegexPropertyName = "((private| |const))* *(string|String) *[A-z]*";
        public string StandardTemplatePath { get; set; }
        public string[] FoldersToAddForCompilation { get; set; }
        public Compiler(){}
        public Compiler(string standTemp, string[] fldToAdd) {
            StandardTemplatePath = standTemp;
            FoldersToAddForCompilation = fldToAdd;
        }
		//[SelfLanguage.Attributes.SelfProperty]
        public bool Compile(string output_path,string selfLanguage) {
            if (StandardTemplatePath.Contains(PutHereSelfLanguage)) {
				
            }
            return false;
        }
    }
}
