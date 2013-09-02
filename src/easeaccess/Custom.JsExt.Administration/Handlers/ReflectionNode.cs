// ReflectionNode.cs
//

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Custom.Handlers
{
    using Ext.data;

    public class ReflectionNode
    {
        public static string Path(NodeInterface node)
        {
            ReflectionNodeObject raw = (ReflectionNodeObject)node.Raw;
            List<string> path = new List<string>();

            if ((bool)(object)raw.name)
            {
                path.Add(raw.name);
            }

            for (node = node.ParentNode; (bool)node; node = node.ParentNode)
            {
                raw = (ReflectionNodeObject)node.Raw;
                path.Add(raw.name);
            }

            path.Reverse();

            return path.Join("/");
        }
    }

    [Imported, IgnoreNamespace, ScriptName("Object")]
    public class ReflectionNodeObject : Ext.data.NodeObject
    {
        public string id;

        public string name;

        public string path;

        public string type;
    }
}
