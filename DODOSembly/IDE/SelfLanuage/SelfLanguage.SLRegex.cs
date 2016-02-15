using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SelfLanguage.SLRegex {
    class RegexContainer {
        private const string MatchRam = @"\s*R\s*:\s*[^\^]*:[^\0&]*";
        private const string MatchStack = @"\s*^-$\s*";
        private const string MatchStackMultiChar = @"\s*-{2}\s*";
        private const string MatchNumber = @"\d*";
        private Regex Ram { get; set; }
        private Regex Stack { get; set; }
        private Regex StackMultiChar { get; set; }
        private Regex Number { get; set; }
        public RegexContainer() {
            Ram = new Regex(MatchRam);
            Stack = new Regex(MatchStack);
            StackMultiChar = new Regex(MatchStackMultiChar);
            Number = new Regex(MatchNumber);
        }
        public SelfLanguageDestination IsCommand(string s) {
            if (Ram.Match(s).Success) {
                return SelfLanguageDestination.Ram;
            } else if (Stack.Match(s).Success) {
                return SelfLanguageDestination.Stack;
            } else if (StackMultiChar.Match(s).Success) {
                return SelfLanguageDestination.StackMultiChar;
            }else if(Number.Match(s).Success){
                return SelfLanguageDestination.Number;
            }else {
                return SelfLanguageDestination.None;
            }
        }
        
    }
    public enum SelfLanguageDestination {
        Ram,
        Stack,
        StackMultiChar,
        Number,
        None
    }
}
