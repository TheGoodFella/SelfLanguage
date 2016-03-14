using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using SelfLanguage.Interfaces;

namespace SelfLanguage.Utility {
    /// <summary>
    /// Type used to log what is happening
    /// </summary>
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
    /// <summary>
    /// Conversion parser
    /// </summary>
    public class ConversionSelector {
        /// <summary>
        /// Returns the possible conversion for the variable
        /// </summary>
        /// <param name="t">Type to be converted to or from</param>
        /// <returns>Possible conversion</returns>
        public PossibleConversion[] GetConversion(Type t) {
            var to_r = new List<PossibleConversion>();
            if(t.GetInterfaces().Any(x=>x == typeof(IStringable))){
                to_r.Add(PossibleConversion.IStringable);
            }
            if(t.GetMethods().Where(s => s.Name == "op_Implicit") //Is a implicit operator
                .Any((k)=>k.GetParameters().Length == 1                 //Just 1 parameter
                    && k.GetParameters().First().GetType() == t         //Parameter of type t
                    && k.ReturnType == typeof(string)))                 //Returns string
            {
                to_r.Add(PossibleConversion.ToStringImplicit);
            }
            if(t.GetMethods().Where(s => s.Name == "op_Implicit")     //Is a implicit operator
                .Any((k)=>k.GetParameters().Length == 1                     //Just 1 parameter
                    && k.GetParameters().First().GetType() == typeof(string)//Parameter of type string
                    && k.ReturnType == t))                                  //Returns t
            {
                to_r.Add(PossibleConversion.FromStringImplicit);
            }
            if(t.GetMethods().Where(s => s.Name == "op_Explicit" || t == typeof(string)) //Is a implicit operator
                .Any((k)=>k.GetParameters().Length == 1                 //Just 1 parameter
                    && k.GetParameters().First().GetType() == t         //Parameter of type t
                    && k.ReturnType == typeof(string)))                 //Returns string
            {
                to_r.Add(PossibleConversion.ToStringExplicit);
            }
            if(t.GetMethods().Where(s => s.Name == "op_Explicit")     //Is a implicit operator
                .Any((k)=>k.GetParameters().Length == 1                     //Just 1 parameter
                    && k.GetParameters().First().GetType() == typeof(string)//Parameter of type string
                    && k.ReturnType == t))                                  //Returns t
            {
                to_r.Add(PossibleConversion.FromStringExplicit);
            }
            if(t.GetInterfaces().Any(s => s == typeof(IConvertible))){
                to_r.Add(PossibleConversion.IConvertible);
            }
            if (t.GetConstructors().Any((e) => e.GetParameters().Length == 1 && e.GetParameters().First().GetType() == typeof(string))) {
                to_r.Add(PossibleConversion.Constructor);
            }
            return to_r.ToArray();
        }
    }
    /// <summary>
    /// This clarify the Conversion hierarchy
    /// </summary>
    public enum PossibleConversion {
        IStringable=4,
        ToStringImplicit = 3,
        ToStringExplicit = 2,
        FromStringImplicit = 3,
        FromStringExplicit = 2,
        IConvertible=1,
        Constructor=1,
    }
}
