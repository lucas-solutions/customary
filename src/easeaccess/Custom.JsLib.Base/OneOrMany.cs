// OneOrMany.cs
//

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System
{
    [Imported, IgnoreNamespace, ScriptName("Object")]
    public class OneOrMany<T>
    {
        public static implicit operator T(OneOrMany<T> value) { return value; }
        public static implicit operator T[](OneOrMany<T> value) { return value; }
        public static implicit operator List<T>(OneOrMany<T> value) { return value; }

        public static implicit operator OneOrMany<T>(T value) { return value; }
        public static implicit operator OneOrMany<T>(T[] value) { return value; }
        public static implicit operator OneOrMany<T>(List<T> value) { return value; }

        public void Push(T item) { }
    }
}
