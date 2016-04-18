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
        public Logging( string message = "", int pointer = -1, Exception rised = default(Exception) ) {
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
        public Variable( object o, string name ) {
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
        Type[] CLRTypes = { typeof(Boolean), typeof(SByte), typeof(Byte), typeof(Int16), typeof(UInt16), typeof(Int32)
                              , typeof(UInt32), typeof(Int64), typeof(UInt64), typeof(Single), typeof(Double), typeof(Decimal), typeof(DateTime), typeof(Char), typeof(String) };
        /// <summary>
        /// Returns the possible conversion for the variable
        /// </summary>
        /// <param name="to">Type to be converted to or from</param>
        /// <returns>Possible conversion</returns>
        public PossibleConversion[] GetConversion( Type to, Type from ) {
            var to_r = new List<PossibleConversion>();
            if ( to == from || to.GetMethods()  //IMPLICIT
                .Where(k => k.Name == "op_Implicit")
                .Any(( k ) => {
                    return k.ReturnType == to && k.GetParameters().Length == 1 && k.GetParameters().FirstOrDefault().ParameterType == from;
                }
                    )
            ) {
                to_r.Add(PossibleConversion.ToImplicit);
            } else if ( to.GetMethods()  //EXPLICIT
                  .Where(k => k.Name == "op_Explicit")
                  .Any(( k ) => {
                      return k.ReturnType == to && k.GetParameters().Length == 1 && k.GetParameters().FirstOrDefault().ParameterType == from;
                  }) ) {
                to_r.Add(PossibleConversion.ToExplicit);
            } else if ( CLRTypes.Any(s => s == to) && from.GetInterfaces().Any(s=>s == typeof(IConvertible)) ) { //CLRTYPES
                to_r.Add(PossibleConversion.IConvertible);
            } else if(to.GetConstructors().Any(s=>s.GetParameters().Length==1 && s.GetParameters().First().ParameterType == from)) {
                to_r.Add(PossibleConversion.Constructor);
            } else if ( to.GetInterfaces().Contains(typeof(IStringable)) && from.GetInterfaces().Contains(IStringable) ) {
                to_r.Add(PossibleConversion.IStringable);
            }
            return to_r.OrderBy(s => (int)s).ToArray();
        }
    }
    /// <summary>
    /// This clarify the Conversion hierarchy
    /// </summary>
    public enum PossibleConversion {
        ToImplicit = 3,
        ToExplicit = 2,
        IConvertible = 2,
        IStringable = 1,
        Constructor = 1,
    }
}
