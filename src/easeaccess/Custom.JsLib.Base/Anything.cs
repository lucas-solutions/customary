// Anything.cs
//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System
{
    [Imported, IgnoreNamespace, ScriptName("Object")]
    public class Anything : NumberOrString
    {
        public static implicit operator Array(Anything value) { return value; }
        public static implicit operator Delegate(Anything value) { return value; }
        public static implicit operator Function(Anything value) { return value; }

        public static implicit operator Anything(Array value) { return value; }
        public static implicit operator Anything(Delegate value) { return value; }
        public static implicit operator Anything(Function value) { return value; }
    }
}
