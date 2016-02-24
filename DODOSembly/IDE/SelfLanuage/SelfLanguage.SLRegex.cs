using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SelfLanguage.SLRegex {
    /// <summary>
    /// SelfLanguage Regex container
    /// </summary>
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

        private const string MatchJumpCondition = @"^(<|!|>|=){1}(\(.*\|).*\)";
        private Regex JumpCondition { get; set; }
        private Dictionary<string, int[]> JumpExpect { get; set; }

        /// <summary>
        /// Creates a new RegexContainer, this is made for performance sake
        /// </summary>
        public RegexContainer() {
            Ram = new Regex(MatchRam);
            Stack = new Regex(MatchStack);
            StackMultiChar = new Regex(MatchStackMultiChar);
            Number = new Regex(MatchNumber);
            Here = new Regex(MatchHere);
            Compare = new Regex(MatchCompare);

            JumpCondition = new Regex(MatchJumpCondition);
            JumpExpect = new Dictionary<string, int[]>();
            JumpExpect.Add("<", new int[]{ 1 });
            JumpExpect.Add("=", new int[]{ 0 });
            JumpExpect.Add(">", new int[]{ 2 });
            JumpExpect.Add("!", new int[]{ 1, 2 });
        }
        /// <summary>
        /// Return wich Destination is the parameter
        /// </summary>
        /// <param name="s">To parse</param>
        /// <returns>The actual destination</returns>
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
        /// <summary>
        /// Parse the jump
        /// </summary>
        /// <param name="s">Jump to be parsed</param>
        /// <returns>Standard Parser output</returns>
        public bool IsConditionalJump(string s) {
            return JumpCondition.Match(s).Success;
        }
        /// <summary>
        /// True or false according to the jump expected and returned value
        /// </summary>
        /// <param name="i">Number to be made as boolean</param>
        /// <param name="s"> \<, \>, = or ! </param>
        /// <returns>true for \< on 1, true for = on 0, true for ! on 1 or 2, true for \> on 2</returns>
        public bool JumpIntToBool(int i, string s) {
            return JumpExpect[s].Any(k => k == i);
        }
    }
    /// <summary>
    /// All the possible destinations
    /// </summary>
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
