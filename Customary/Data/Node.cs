using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Data
{
    using Raven.Abstractions.Data;
    using Raven.Json.Linq;

    public abstract class Node
    {
        private string _key;
        private string _name;
        private WeakReference<JsonDocument> _document;
        private WeakReference<RavenJObject> _value;
        private Area _parent;

        protected Node(Area parent)
        {
            _parent = parent;
        }

        public JsonDocument Document
        {
            get
            {
                if (string.IsNullOrEmpty(_key))
                    return null;

                JsonDocument document;

                if (_document.TryGetTarget(out document))
                    return document;

                document = Global.Metadata.Store.DatabaseCommands.Get(_key);

                _document.SetTarget(document);

                return document;
            }
        }

        public string Id
        {
            get { return string.IsNullOrEmpty(_key) ? null : _key.Split('/').Last(); }
        }

        public string Key
        {
            get { return _key; }
        }

        public string Name
        {
            get { return _name; }
        }

        public string Path
        {
            get { return _parent != null ? _parent.Path + '/' + _name : _name; }
        }

        public RavenJObject Value
        {
            get
            {
                RavenJObject value;

                if (_value != null && _value.TryGetTarget(out value))
                    return value;

                value = Document.DataAsJson.CreateSnapshot() as RavenJObject;

                if (_value != null)
                    _value.SetTarget(value);
                else
                    _value = new WeakReference<RavenJObject>(value);

                return value;
            }
        }

        private static int Compare(Node x, Node y)
        {
            int result;

            result = string.Compare(x._name, y._name, true);

            return result;
        }

        private static int Compare(JsonDocument x, JsonDocument y)
        {
            int result;

            result = string.Compare(x.DataAsJson.Value<string>("Name"), y.DataAsJson.Value<string>("Name"), true);

            return result;
        }

        /*public static Directory Load(IDocumentStore store)
        {
            Directory root;
            var children = store.StartWith("Area/", Compare);

            var area = children.FirstOrDefault(o => string.IsNullOrEmpty(o.DataAsJson.Value<string>("Name")));

            if (area == null)
                root = new Directory { _children = new LinkedList<Directory>() };
            else
            {
                children.Remove(area);

                root = new Directory
                {
                    _key = area.Key,
                    _document = new WeakReference<JsonDocument>(area),
                    _children = new LinkedList<Directory>()
                };
            }

            children.AddRange(store.StartWith("Type/", Compare));

            children.Sort(Compare);

            root.Merge(children, 0);

            root.Freeze();

            return root;
        }

        public Directory MatchExact(string path)
        {
            Queue<string> surplus;
            var directory = Match(path.Split('/').AsEnumerable().GetEnumerator(), out surplus);
            return surplus == null || surplus.Count.Equals(0) ? directory : null;
        }*/
    }
}