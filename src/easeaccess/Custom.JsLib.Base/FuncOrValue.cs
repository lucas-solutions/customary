// FuncOrValue.cs
//

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace System
{
    [Imported, IgnoreNamespace, ScriptName("Object")]
    public class FuncOrValue<T> : JObject
    {
        public static implicit operator T(FuncOrValue<T> value) { return value; }
        public static implicit operator Func<T>(FuncOrValue<T> value) { return value; }

        public static implicit operator FuncOrValue<T>(T value) { return value; }
        public static implicit operator FuncOrValue<T>(Func<T> value) { return value; }
    }
}
