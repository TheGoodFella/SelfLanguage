using System;
using System.Collections.Generic;
using System.Linq;

namespace SelfLanguage.TypeAlias {
    /// <summary>
    /// Class designed to contain all the type alias used by the SelfLanguage
    /// </summary>
    class SelfTypes {
        Dictionary<string, Type> Aliasses { get; set; }
        /// <summary>
        /// Creates a new instance of SelfTypes
        /// </summary>
        public SelfTypes() {
            Aliasses = new Dictionary<string, Type>();
            Aliasses.Add("str"   , typeof(String));
            Aliasses.Add("int"   , typeof(Int32));
            Aliasses.Add("int16" , typeof(Int16));
            Aliasses.Add("int32" , typeof(Int32));
            Aliasses.Add("int64" , typeof(Int64));
            Aliasses.Add("obj"   , typeof(Object));
            Aliasses.Add("dou"   , typeof(Double));
            Aliasses.Add("float" , typeof(float));
        }
        /// <summary>
        /// Returns null if not contained in aliasses
        /// </summary>
        public Type GetFromAlias(string s) {
            if (Aliasses.ContainsKey(s)) {
                return Aliasses[s];
            } else {
                return null;
            }
        }
        /// <summary>
        /// Gets all pair alias, and full name [Alias;FullTypeName]
        /// </summary>
        public string[] GetAllAliassesWithStringName() {
            return Aliasses.Select((s) => string.Format("{0};{1}",s.Key,s.Value.FullName)).ToArray();
        }
    }
}
