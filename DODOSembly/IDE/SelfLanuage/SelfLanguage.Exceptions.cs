using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfLanguage.Exceptions {
    /// <summary>
    /// The variable is not defined
    /// </summary>
    class NotDefinedVariableException : Exception {
        private string _Message { get; set; }
        public override string Message {
            get {
                return _Message;
            }
        }
        public NotDefinedVariableException(string s) {
            _Message = s;
        }
        public NotDefinedVariableException() {
            _Message = "The variable is not defined";
        }
    }
    /// <summary>
    /// The Interrupt is empty or not defined
    /// </summary>
    class EmptyInterruptException : Exception {
        private string _Message { get;set; }
        public override string Message {
            get {
                return _Message;
            }
        }
        public EmptyInterruptException() {
            _Message = "The called interrupt is empty";
        }
        public EmptyInterruptException(string s) {
            _Message = s;
        }
    }
    /// <summary>
    /// The given entry point is not valid
    /// </summary>
    class InvalidProgramEntryPointException : Exception {
        private string _Message { get; set; }
        public override string Message {
            get {
                return _Message;
            }
        }
        public InvalidProgramEntryPointException() {
            _Message = "The specified entry point is not a valid starting command or is over,or beyond the memory limits";
        }
        public InvalidProgramEntryPointException(string s) {
            _Message = s;
        }
    }
    /// <summary>
    /// The given pointer in not valid
    /// </summary>
    class InvalidPointerException : Exception {
        private string _Message { get; set; }
        public override string Message {
            get {
                return _Message;
            }
        }
        public InvalidPointerException() {
            _Message="The specified pointer is over or beyond the memory bound, or is not a valid pointer";
        }
        public InvalidPointerException(string s) {
            _Message = s;
        }
    }
    /// <summary>
    /// The type to generate might not be string parsable or have no string constructor
    /// </summary>
    class InvalidTypeGeneratorException : Exception {
        private string _Message { get; set; }
        public override string Message {
            get {
                return _Message;
            }
        }
        public InvalidTypeGeneratorException() {
            _Message = "Invalid type generator exception, the type to generate might not be string parsable or have no string constructor";
        }
        public InvalidTypeGeneratorException(string s) {
            _Message = s;
        }

    }
    /// <summary>
    /// The given move is not valid
    /// </summary>
    class InvalidMoveException : Exception {
        public InvalidMoveException(string s):base(s) { }
    }
    /// <summary>
    /// The setter is not valid
    /// </summary>
    class InvalidSetterException : Exception {
        public InvalidSetterException(string s):base(s){ }
    }
    /// <summary>
    /// The getter is not valid
    /// </summary>
    class InvalidGetterException : Exception {
        public InvalidGetterException(string s): base(s) { }
    }
    /// <summary>
    /// The Variable type is not valid
    /// </summary>
    class InvalidVariableTypeException : Exception {
        public InvalidVariableTypeException(string s) : base(s) { }
    }
    /// <summary>
    /// The Jump is not valid
    /// </summary>
    class InvalidJumpException : Exception {
        public InvalidJumpException(string s): base(s) { }
    }
}
