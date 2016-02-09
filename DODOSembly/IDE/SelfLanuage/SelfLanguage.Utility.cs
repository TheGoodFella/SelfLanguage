using System;
using System.Reflection;

namespace SelfLanguage.Utility {
    public class Logging {
        public string Message;
        public int Pointer;
        public Exception RisedException;
        public Logging(string message = "", int pointer = -1, Exception rised = default(Exception)) {
            Message = message;
            Pointer = pointer;
            RisedException = rised;
        }
    }
    /// <summary>
    /// Variable type used in the language
    /// </summary>
    public class Variable {
        /// <summary>
        /// The variable name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The Value of the variable
        /// </summary>
        public object IncapsulatedValue { get; set; }
        /// <summary>
        /// Create a new instance of Variable using the actual value and the name
        /// </summary>
        /// <param name="o"></param>
        /// <param name="name"></param>
        public Variable(object o, string name) {
            this.IncapsulatedValue = o;
            this.Name = name;
        }
        /// <summary>
        /// Returns the type of the variable and not the typeof(Variable)
        /// </summary>
        /// <returns>IncapsulatedValue.GetType()</returns>
        public new Type GetType() {
            return IncapsulatedValue.GetType();
        }
    }
}
