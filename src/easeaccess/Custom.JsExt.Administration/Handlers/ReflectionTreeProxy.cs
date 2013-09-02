// Proxy.cs
//

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Custom.Handlers
{
    using Ext.data;
    using Ext.tree;

    public class ReflectionTreeProxy
    {
        public string BuildUrl(Request request)
        {
            string url = ReflectionNode.Path(request.Operation.Node);
            ReflectionNodeObject raw = (ReflectionNodeObject)request.Operation.Node.Raw;
            return (bool)(object)raw.path ? url + '/' + raw.path : url;
        }
    }
}
