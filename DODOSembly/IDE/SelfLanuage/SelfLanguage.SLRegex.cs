using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SelfLanguage.SLRegex {
    class RegexContainer {
        private const string MatchRam = @"^R\s*:\s*[^\^]*:[^\0&]*";
        private Regex Ram { get; set; }
        private const string MatchCompare = @"^\((.*|){2}.*\)";
        private Regex Compare { get; set; }
        private const string MatchStack = @"^-$";
        private Regex Stack { get; set; }
        private const string MatchStackMultiChar = @"^-{2}";
        private Regex StackMultiChar { get; set; }
        private const string MatchNumber = @"^\d+$";
        private Regex Number { get; set; }
        private const string MatchHere = @"^\^[^\0&]*";
        private Regex Here { get; set; }
        

        public RegexContainer() {
            Ram = new Regex(MatchRam);
            Stack = new Regex(MatchStack);
            StackMultiChar = new Regex(MatchStackMultiChar);
            Number = new Regex(MatchNumber);
            Here = new Regex(MatchHere);
            Compare = new Regex(MatchCompare);
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
            }else if(Here.Match(s).Success){
                return SelfLanguageDestination.Here;
            } else if (Compare.Match(s).Success) {
                return SelfLanguageDestination.Compare;
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
        Compare,
        Here,
        None
    }
}
