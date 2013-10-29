using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http.Dispatcher;

namespace Custom.Web.Http
{
    public class ApiAssembliesResolver : IAssembliesResolver
    {
        public ICollection<Assembly> GetAssemblies()
        {
            throw new NotImplementedException();
        }
    }
}