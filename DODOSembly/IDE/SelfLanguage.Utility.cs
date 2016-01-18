﻿using System;

namespace SelfLanguage.Utility {
    class Logging {
        public string Message;
        public int Pointer;
        public Logging(string message = "", int pointer = -1) {
            Message = message;
            Pointer = pointer;
        }
    }
    /// <summary>
    /// Variable type used in the language
    /// </summary>
    class Variable {
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
