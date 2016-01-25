using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfLanguage.Attributes {
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    class SelfPropertyAttributeCode : Attribute {

    }
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    class SelfPropertyAttributeEntryPoint : Attribute {

    }
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    class SelfPropertyAttributeMemoryToAlloc : Attribute {

    }
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    class SelfMethodAttributeRun : Attribute {

    }
}
