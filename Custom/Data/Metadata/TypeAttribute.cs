using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Data.Metadata
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public abstract class TypeAttribute : DefinitionAttribute
    {
        private readonly Guid _id;

        protected TypeAttribute(string id)
        {
            _id = new Guid(id);
        }

        public Guid Id
        {
            get { return _id; }
        }
    }
}
