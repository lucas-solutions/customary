using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Metadata
{
    using Raven.Abstractions.Data;
    using Raven.Client;
    using Raven.Json.Linq;

    public class Directory
    {
        private static Random _idGenerator = new Random();

        private string _id;
        private string _type;
        private string _name;
        private WeakReference<JsonDocument> _document;
        private ICollection<Directory> _children;
        
        private Directory()
        {
        }

        private Directory(string name, JsonDocument document)
        {
            var key = document.Key.Split('/');

            _id = key.Last();
            _type = key.Reverse().Skip(1).FirstOrDefault();
            _name = name;
            _document = new WeakReference<JsonDocument>(document);
        }

        private Directory(string name, Directory child)
        {
            _name = name;
            _children = new LinkedList<Directory>();
            _children.Add(child);
        }

        public string Id
        {
            get { return _id; }
        }

        public ICollection<Directory> Items
        {
            get { return _children; }
        }

        public string Name
        {
            get { return _name; }
        }

        public RavenJObject Value
        {
            get;
            set;
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

            var children = new LinkedList<Directory>();
            var count = 0;

            for (var start = 0; true; count = start)
            {
                var documents = store.DatabaseCommands.StartsWith("Type/", null, start, pageSize);

                Array.Sort(documents, Compare);

                Merge(children, documents, 0);

                if (documents.Length < pageSize)
                    break;

                start += documents.Length;
            }

            var result = new Directory { _children = children };

            result.Freeze();

            return result;
        }

        public Directory Match(IEnumerator<string> iterator)
        {
            if (!iterator.MoveNext())
                return this;

            if (_children == null)
                return null;

            var match = _children.FirstOrDefault(o => string.Equals(o._name, iterator.Current, StringComparison.CurrentCultureIgnoreCase));

            return match != null ? match.Match(iterator) : null;
        }

        private static ICollection<Directory> Merge(ICollection<Directory> items, JsonDocument[] documents, int start)
        {
            for (var i = start; i < documents.Length; i++)
                Merge(items, documents[i]);

            return items;
        }

        private static ICollection<Directory> Merge(ICollection<Directory> items, JsonDocument document)
        {
            var next = Split(document);

            if (items.Count == 0)
            {
                items.Add(next);
                return items;
            }

            var last = items.Last();

            if (string.Equals(last._name, next._name, StringComparison.CurrentCultureIgnoreCase))
                Merge(last._children, next._children);
            else
                items.Add(next);

            return items;
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

            if (string.Equals(last._name, next._name, StringComparison.CurrentCultureIgnoreCase))
            {
                Merge(last._children, next._children);
                skip = 1;
            }

            foreach (var item in right.Skip(skip))
                left.Add(item);

            return left;
        }

        private static Directory Split(JsonDocument document)
        {
            var data = document.DataAsJson;
            var name = data.Value<string>("Name");
            var slice = name.Split('.');

            var node = new Directory(slice[slice.Length - 1], document);

            for (var i = slice.Length - 2; i > -1; i--)
                node = new Directory(slice[i], node);

            return node;
        }

        public RavenJObject ToRavenJObject(bool deep)
        {
            var value = Value;

            if (value != null)
                value = value.CreateSnapshot() as RavenJObject;
            else
                value = new RavenJObject();

            if (!string.IsNullOrEmpty(_id))
                value["id"] = new RavenJValue(_id);
            else
                value["id"] = new RavenJValue(Guid.NewGuid().ToString("N")/*_name + _idGenerator.Next(10, 99).ToString()*/);

            if (_type != null)
                value["type"] = new RavenJValue(_type);

            value["text"] = new RavenJValue(_name);

            if (_children == null)
                value["leaf"] = new RavenJValue(true);
            else if (deep)
            {
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