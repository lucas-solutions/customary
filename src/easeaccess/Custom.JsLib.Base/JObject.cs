// JObject.cs
//

using System;
using System.Collections;
using System.Runtime.CompilerServices;

namespace System
{
    [Imported, IgnoreNamespace, ScriptName("Object")]
    public class JObject
    {
        public static implicit operator Boolean(JObject value) { return value; }
        public static implicit operator Dictionary(JObject value) { return value; }

        public static implicit operator JObject(Boolean value) { return value; }
        public static implicit operator JObject(Dictionary value) { return value; }

        public JObject() { }
        public JObject(params object[] nameValuePairs) { }
    }
}
