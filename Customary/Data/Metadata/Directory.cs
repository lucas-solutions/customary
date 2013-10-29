using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Data.Metadata
{
    using Raven.Abstractions.Data;
    using Raven.Client;
    using Raven.Json.Linq;

    public class Directory
    {
        private string _key;
        private string _name;
        private WeakReference<JsonDocument> _document;
        private WeakReference<RavenJObject> _value;
        private ICollection<Directory> _children;
        private Directory _parent;

        private Directory()
        {
            _name = string.Empty;
        }

        private Directory(string name, JsonDocument document, Directory parent)
        {
            _name = name;
            _key = document.Key;
            _document = new WeakReference<JsonDocument>(document);
            _parent = parent;
        }

        private Directory(string name, Directory child)
        {
            _name = name;
            _children = new LinkedList<Directory>();
            _children.Add(child);
        }

        public ICollection<Directory> Children
        {
            get { return _children; }
        }

        public JsonDocument Document
        {
            get
            {
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
            get { return _key.Split('/').Last(); }
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

        public string Type
        {
            get { return _key.Split('/').Reverse().Skip(1).FirstOrDefault(); }
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

        private static int Compare(Directory x, Directory y)
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

        private void Freeze()
        {
            if (_children != null)
            {
                var children = _children.ToArray();

                Array.Sort(children, Compare);

                foreach (var child in children)
                    child.Freeze();

                _children = children;
            }
        }

        public static Directory Load(IDocumentStore store)
        {
            const int pageSize = 400;

            var count = 0;

            var root = new Directory { _children = new LinkedList<Directory>() };

            for (var start = 0; true; count = start)
            {
                var documents = store.DatabaseCommands.StartsWith("Type/", null, start, pageSize);

                Array.Sort(documents, Compare);

                root.Merge(documents, 0);

                if (documents.Length < pageSize)
                    break;

                start += documents.Length;
            }

            root.Freeze();

            return root;
        }

        public Directory MatchExact(string path)
        {
            Queue<string> surplus;
            var directory = Match(path.Split('/').AsEnumerable().GetEnumerator(), out surplus);
            return surplus == null || surplus.Count.Equals(0) ? directory : null;
        }

        public Directory Match(IEnumerator<string> iterator, out Queue<string> surplus)
        {
            surplus = null;

            if (iterator.MoveNext())
            {
                if (_children != null)
                {
                    var child = _children.FirstOrDefault(o => string.Equals(o.Name, iterator.Current, StringComparison.CurrentCultureIgnoreCase));

                    if (child != null)
                        return child.Match(iterator, out surplus);
                }

                surplus = new Queue<string>();
                surplus.Enqueue(iterator.Current);
                while (iterator.MoveNext())
                    surplus.Enqueue(iterator.Current);
            }

            return this;
        }

        private ICollection<Directory> Merge(JsonDocument[] documents, int start)
        {
            for (var i = start; i < documents.Length; i++)
                Merge(documents[i]);

            return _children;
        }

        private ICollection<Directory> Merge(JsonDocument document)
        {
            var next = Split(document);

            if (_children.Count == 0)
            {
                _children.Add(next);
                return _children;
            }

            var last = _children.Last();

            if (string.Equals(last.Name, next.Name, StringComparison.CurrentCultureIgnoreCase))
                Merge(last._children, next._children);
            else
                _children.Add(next);

            return _children;
        }

        private static ICollection<Directory> Merge(ICollection<Directory> left, ICollection<Directory> right)
        {
            if (right == null || right.Count == 0)
                return left;

            if (left == null || left.Count == 0)
                return right;

            var last = left.Last();
            var next = right.First();
            var skip = 0;

            if (string.Equals(last.Name, next.Name, StringComparison.CurrentCultureIgnoreCase))
            {
                Merge(last._children, next._children);
                skip = 1;
            }

            foreach (var item in right.Skip(skip))
                left.Add(item);

            return left;
        }

        private Directory Split(JsonDocument document)
        {
            var data = document.DataAsJson;
            var path = (data.Value<string>("Name") ?? string.Empty).Split('/');
            var name = path.Last();

            var node = new Directory(name, document, this);

            for (var i = path.Length - 2; i > -1; i--)
                node = new Directory(path[i], node);

            return node;
        }

        public RavenJObject ToRavenJObject(bool deep)
        {
            var value = Value;

            if (value != null)
                value = value.CreateSnapshot() as RavenJObject;
            else
                value = new RavenJObject();

            value["text"] = new RavenJValue(Name);

            if (_key != null)
            {
                value["id"] = new RavenJValue(Id);
                value["key"] = new RavenJValue(Key);
                value["leaf"] = new RavenJValue(true);
                value["type"] = new RavenJValue(Type);
            }
            else if (deep)
            {
                value["id"] = new RavenJValue(Path);
                value["children"] = new RavenJArray(_children.Select(o => o.ToRavenJObject(false)).AsEnumerable<RavenJToken>());
            }

            // allowDrag
            // name
            // text
            // type
            // raw

            return value;
        }
    }
}