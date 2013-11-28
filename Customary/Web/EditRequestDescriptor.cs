using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Custom.Web
{
    [Obsolete]
    public class EditRequestDescriptor : RequestDescriptor
    {
        public EditRequestDescriptor(RequestContext requestContext, string controllerName)
            : base(requestContext, controllerName)
        {
        }

        protected override void Initialize()
        {
        }
    }
}