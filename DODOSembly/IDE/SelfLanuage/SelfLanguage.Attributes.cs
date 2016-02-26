using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfLanguage.Attributes {
    /// <summary>
    /// Attribute for Code in application template
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public class SelfPropertyAttributeCode : Attribute {

    }
    /// <summary>
    /// Attribute for EntryPoint in application template
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public class SelfPropertyAttributeEntryPoint : Attribute {

    }
    /// <summary>
    /// Attribute for memory to alloc in application template
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public class SelfPropertyAttributeMemoryToAlloc : Attribute {

    }
    /// <summary>
    /// Attribute for run property in application template
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class SelfMethodAttributeRun : Attribute {

    }
}
