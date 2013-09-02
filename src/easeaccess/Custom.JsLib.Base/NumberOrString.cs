// NumberOrString.cs
//

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System
{
    [Imported, IgnoreNamespace, ScriptName("Object")]
    public class NumberOrString
    {
        public static implicit operator Boolean(NumberOrString value) { return value; }
        public static implicit operator Number(NumberOrString value) { return value; }
        public static implicit operator String(NumberOrString value) { return value; }

        public static implicit operator NumberOrString(Boolean value) { return value; }
        public static implicit operator NumberOrString(Number value) { return value; }
        public static implicit operator NumberOrString(String value) { return value; }
    }
}
