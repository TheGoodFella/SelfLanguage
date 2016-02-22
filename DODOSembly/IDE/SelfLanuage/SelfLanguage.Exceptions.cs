using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfLanguage.Exceptions {
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
    class InvalidMoveException : Exception {
        public InvalidMoveException(string s):base(s) { }
    }
    class InvalidSetterException : Exception {
        public InvalidSetterException(string s):base(s){ }
    }
    class InvalidGetterException : Exception {
        public InvalidGetterException(string s): base(s) { }
    }
    class InvalidVariableTypeException : Exception {
        public InvalidVariableTypeException(string s) : base(s) { }
    }
    class InvalidJumpException : Exception {
        public InvalidJumpException(string s): base(s) { }
    }
}
