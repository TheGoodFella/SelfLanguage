using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainFuck {
    class BrainFuck {
        int _ptr { get; set; }
        int _memoryptr { get; set; }
        Stack<Jump> Jump { get; set; }
        Char[] _program { get; set; }
        Char[] _memory { get; set; }
        Dictionary<char, Action> moves;

        public event EventHandler<char[]> OnMemoryEdit;
        public event EventHandler<char[]> OnEnd;
        public event EventHandler<char>   OnDot;

        public void Start() {
            if ( OnEnd == null || OnDot == null ) { throw new NullReferenceException("OnEnd or OnDot or both are null"); }
            while ( _program[_ptr] != '\\' ) {
                var to_do = _program[_ptr];
                if ( moves.ContainsKey(to_do) ) {
                    moves[to_do]();
                }
                _ptr++;
            }
            OnEnd(this, _program.Select(s => (char)s).ToArray());
        }
        #region Constructors
        /// <summary>
        /// Default constructor
        /// </summary>
        public BrainFuck() {
            moves = new Dictionary<char, Action>();
            moves.Add('<', () => this._memoryptr--);
            moves.Add('>', () => this._memoryptr++);
            moves.Add('+', () => this._memory[_memoryptr]++);
            moves.Add('-', () => this._memory[_memoryptr]--);
            moves.Add('.', () => this.OnDot(this, (char)_memory[_memoryptr++])); //Write and then increment
            moves.Add('[', () => StartJump());
            moves.Add(']', () => EndJump());
            //moves.Add('\\', () => OnEnd(this, _memory.Select(s=>(char)s).ToArray())); 
        }
        /// <summary>
        /// Useful constructor to call when the pointer is not 0 at the beginning
        /// or the memory is loaded from another place
        /// </summary>
        /// <param name="pointer">Starting pointer</param>
        /// <param name="memory">Memory initial status</param>
        public BrainFuck(int pointer=0,char[] memory =null):this() {
            if ( memory != null ) {
                this._memory = memory;
            } else {
                memory = new char[1024];
            }
            _ptr = pointer;
        }
        #endregion
        public void LoadProgram(char[] program) {
            _program = program;
        }
        private void EndJump() {
            _ptr = Jump.FirstOrDefault().Start;
        }
        private void StartJump() {
            if (! Jump.Any(z => z.Start == _ptr) ) {
                var end_of_j = _ptr;
                while ( _program[end_of_j] !=']') {
                    end_of_j++;
                }
                Jump.Push(new Jump(_ptr, end_of_j));
            }
            if (_program[_ptr]==0) {
                _ptr = Jump.Pop().End+1;
            } else {
                _ptr++;
            }
        }
    }
    class Jump {
        public int Start { get; set; }
        public int End { get; set; }
        public Jump( int start, int end ) {
            this.Start = start; this.End = end;
        }
        public Jump() {

        }
    }
}
