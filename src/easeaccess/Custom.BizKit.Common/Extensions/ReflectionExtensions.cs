using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Extensions
{
    using Custom.Models;
    using Raven.Abstractions.Data;

    public static class ReflectionExtensions
    {
        public static void SaveChanges(this Reflection self)
        {
            var me = self as UriReflection;

            me.SaveChanges();
        }

        public static Stack<PatchRequest> Stack(this Reflection self)
        {
            var me = self as UriReflection;

            return me.Stack;
        }
    }
}
