using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Custom.Data
{
    using Raven.Abstractions.Data;
    using Raven.Client;
    using Raven.Json.Linq;

    public class DataDictionary : NameDescriptor
    {
        private readonly static object _lock = new object();

        private static DataDictionary _singleton;

        private DataDictionary()
            : base(null, null)
        {
            _items = Load(Global.Metadata.Store);
            
            // "Raven/Replication/Destinations"
            //Global.Metadata.Store.Conventions.ReplicationInformerFactory = (string name) => { return null; };
        }

        public static DataDictionary Current
        {
            get
            {
                var instance = _singleton;

                if (instance == null)
                {
                    lock (_lock)
                    {
                        instance = _singleton ?? (_singleton = new DataDictionary());
                    }
                }

                return instance;
            }
        }

        public override NodeKinds Type
        {
            get { return NodeKinds.Name; }
        }

        public NameDescriptor Describe(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return this;
            }

            Queue<string> surplus;

            var descriptor = Match(this, name.Split('/').AsEnumerable().GetEnumerator(), out surplus);

            Debug.Assert(descriptor != null);

            if (surplus != null && !surplus.Count.Equals(0))
            {
                return null;
            }

            return descriptor;
        }

        public NameDescriptor Match(string name, out Queue<string> surplus)
        {
            var descriptor = Match(this, name.Split('/').AsEnumerable().GetEnumerator(), out surplus);

            Debug.Assert(descriptor != null);

            return descriptor;
        }

        public static List<NameDescriptor> Load(IDocumentStore store)
        {
            const int pageSize = 400;

            int area, type;
            
            var list = new List<NameDescriptor>();

            for (type = 0; ; )
            {
                var documents = store.DatabaseCommands.StartsWith("Type/", null, type, pageSize);

                Array.Sort(documents, Compare);

                for (var i = 0; i < documents.Length; i++)
                {
                    var descriptor = Describe(documents[i]);
                    Patch(list, descriptor.Root);
                }

                type += documents.Length;

                if (documents.Length < pageSize)
                    break;
            }

            for (area = 0; ; )
            {
                var documents = store.DatabaseCommands.StartsWith("Area/", null, area, pageSize);

                Array.Sort(documents, Compare);

                for (var i = 0; i < documents.Length; i++)
                {
                    var descriptor = Describe(documents[i]);
                    Patch(list, descriptor.Root);
                }

                area += documents.Length;

                if (documents.Length < pageSize)
                    break;
            }

            TrimExcess(list);

            return list;
        }

        public override RavenJObject ToRavenJObject(bool deep)
        {
            return base.ToRavenJObject(deep);
        }
    }
}