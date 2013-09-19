using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.Ext
{
    public struct Require
    {
        public string Owner;
        public string Class;
    }

    public class Requires : List<Require>
    {
        public Requires Add<T>()
            where T : class
        {
            var type = typeof(T);
            var name = type.ClassName();
            if (!this.Any(o => name.Equals(o.Class)))
                Add(new Require
                    {
                        Class = name
                    });
            return this;
        }
    }
}