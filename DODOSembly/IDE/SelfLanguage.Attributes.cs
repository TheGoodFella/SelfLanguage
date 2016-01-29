using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfLanguage.Attributes {
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public class SelfPropertyAttributeCode : Attribute {

    }
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public class SelfPropertyAttributeEntryPoint : Attribute {

    }
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public class SelfPropertyAttributeMemoryToAlloc : Attribute {

    }
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class SelfMethodAttributeRun : Attribute {

    }
}
