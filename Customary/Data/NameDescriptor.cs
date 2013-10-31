using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Data
{
    using Raven.Abstractions.Data;
    using Raven.Client;
    using Raven.Json.Linq;

    public class NameDescriptor : IComparable<NameDescriptor>
    {
        protected const string nameKey = "Name";
        protected const string idFormat = "N";

        protected string _name;
        protected List<NameDescriptor> _items;
        private NameDescriptor _parent;

        protected NameDescriptor(string name, NameDescriptor parent)
        {
            _name = name;
            _parent = parent;
        }

        public virtual NodeKinds Type
        {
            get { return NodeKinds.Name; }
        }

        public string Name
        {
            get { return _name; }
        }

        public string Path
        {
            get { return _parent != null ? _parent.Path + '/' + _name : _name; }
        }

        public NameDescriptor Parent
        {
            get { return _parent; }
        }

        public NameDescriptor Root
        {
            get
            {
                NameDescriptor result;

                if (_parent == null)
                    result = this;
                else
                    for (result = _parent; result._parent != null; result = result._parent) ;

                return result;
            }
        }

        protected static int Compare(NameDescriptor x, NameDescriptor y)
        {
            int result;

            result = string.Compare(x._name, y._name, true);

            return result;
        }

        protected static int Compare(JsonDocument x, JsonDocument y)
        {
            int result;

            result = string.Compare(x.DataAsJson.Value<string>(nameKey), y.DataAsJson.Value<string>(nameKey), true);

            return result;
        }

        protected static void TrimExcess(List<NameDescriptor> items)
        {
            if (items != null)
            {
                items.TrimExcess();

                for (var i = 0; i < items.Count; i++)
                    TrimExcess(items[i]._items);
            }
        }

        protected static void Patch(List<NameDescriptor> items, NameDescriptor descriptor)
        {
            if (items == null)
            {
                items = new List<NameDescriptor>();
                items.Add(descriptor);
            }
            else if (items.Count.Equals(0))
                items.Add(descriptor);
            else
            {
                var index = items.BinarySearch(descriptor);

                if (index < 0)
                    items.Insert(index = ~index, descriptor);
                else
                {
                    var children = descriptor._items;

                    if (children != null)
                    {
                        var offspring = items[index]._items ?? new List<NameDescriptor>();

                        foreach (var child in children)
                            Patch(offspring, child);

                        descriptor._items = offspring;
                    }

                    descriptor._items = items[index]._items;

                    items[index] = descriptor;
                }
            }
        }

        protected static NameDescriptor Match(NameDescriptor current, IEnumerator<string> iterator, out Queue<string> surplus)
        {
            if (!iterator.MoveNext())
            {
                surplus = null;
                return current;
            }

            var items = current._items;

            if (items != null)
            {
                var index = current._items.BinarySearch(new NameDescriptor(iterator.Current, null));

                if (index >= 0)
                    return Match(current._items[index], iterator, out surplus);
            }

            surplus = new Queue<string>();
            surplus.Enqueue(iterator.Current);
            while (iterator.MoveNext())
                surplus.Enqueue(iterator.Current);

            return current;
        }

        private static ErrorDescriptor DescribeError(string name, NameDescriptor parent, JsonDocument jsonDocument, string format, params object[] args)
        {
            var message = string.Format(format, args);

            // TODO: Log error

            return new ErrorDescriptor(name, parent, jsonDocument, message);
        }

        protected static NameDescriptor Describe(JsonDocument jsonDocument)
        {
            const string DocumentKeyError = "Document key must match \"[Area|Type]/*\"";
            const string DocumentDataMissingError = "Document data error. {0} is required";
            const string AreaDocumentKeyError = "Area document key must match \"Area/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx\"";
            const string TypeDocumentKeyError = "Type document key must match \"Type/[Enum|Model|Unit|Value]/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx\"";

            var key = jsonDocument.Key;
            var dataAsJson = jsonDocument.DataAsJson;
            var pathString = dataAsJson.Value<string>(nameKey);

            if (string.IsNullOrEmpty(pathString))
                return DescribeError(key, null, jsonDocument, DocumentDataMissingError, nameKey);

            var keyTokens = key.Split('/');
            var pathTokens = pathString.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

            NameDescriptor parent;

            switch (pathTokens.Length)
            {
                case 0:
                    return DescribeError(key, null, jsonDocument, DocumentDataMissingError, nameKey);

                case 1:
                    parent = null;
                    break;

                default:
                    parent = new NameDescriptor(pathTokens[0], null) { _items = new List<NameDescriptor>(1) };
                    for (var i = 1; i < pathTokens.Length - 1; i++)
                    {
                        var child = new NameDescriptor(pathTokens[i], parent) { _items = new List<NameDescriptor>(1) };
                        parent._items.Add(child);
                        parent = child;
                    }
                    break;
            }

            Guid id;
            NodeKinds nodeKind;
            TypeCategories typeCategory;
            NameDescriptor descriptor;

            var name = pathTokens[pathTokens.Length - 1];

            if (System.Enum.TryParse<NodeKinds>(keyTokens[0], true, out nodeKind))
                switch (nodeKind)
                {
                    case NodeKinds.Area:
                        if (2.Equals(keyTokens.Length))
                            if (Guid.TryParse(keyTokens[1], out id))
                                descriptor = new AreaDescriptor(id, name, parent, jsonDocument);
                            else
                                descriptor = DescribeError(name, parent, jsonDocument, AreaDocumentKeyError);
                        else
                            descriptor = DescribeError(name, parent, jsonDocument, AreaDocumentKeyError);
                        break;

                    case NodeKinds.Type:
                        if (3.Equals(keyTokens.Length))
                            if (System.Enum.TryParse<TypeCategories>(keyTokens[1], true, out typeCategory))
                                if (Guid.TryParse(keyTokens[2], out id))
                                    switch (typeCategory)
                                    {
                                        case TypeCategories.Enum:
                                            descriptor = new EnumDescriptor(id, name, parent, jsonDocument);
                                            break;

                                        case TypeCategories.Model:
                                            descriptor = new ModelDescriptor(id, name, parent, jsonDocument);
                                            break;

                                        case TypeCategories.Unit:
                                            descriptor = new UnitDescriptor(id, name, parent, jsonDocument);
                                            break;

                                        case TypeCategories.Value:
                                            descriptor = new ValueDescriptor(id, name, parent, jsonDocument);
                                            break;

                                        default:
                                            descriptor = DescribeError(name, parent, jsonDocument, TypeDocumentKeyError);
                                            break;
                                    }
                                else
                                    descriptor = DescribeError(name, parent, jsonDocument, TypeDocumentKeyError);
                            else
                                descriptor = DescribeError(name, parent, jsonDocument, TypeDocumentKeyError);
                        else
                            descriptor = DescribeError(name, parent, jsonDocument, TypeDocumentKeyError);
                        break;

                    default:
                        descriptor = DescribeError(name, parent, jsonDocument, DocumentKeyError);
                        break;
                }
            else
                descriptor = DescribeError(name, parent, jsonDocument, DocumentKeyError);

            if (parent != null)
            {
                parent._items.Add(descriptor);
            }

            return descriptor;
        }

        public virtual RavenJObject ToRavenJObject(bool deep)
        {
            var result = new RavenJObject();

            result["text"] = new RavenJValue(Name);
            result["type"] = new RavenJValue(System.Enum.GetName(typeof(NodeKinds), Type));

            if (deep)
            {
                var items = _items;

                if (items != null)
                {
                    result["children"] = new RavenJArray(_items.Select(o => o.ToRavenJObject(false)).AsEnumerable<RavenJToken>());
                }
            }

            // allowDrag
            // name
            // text
            // type
            // raw

            return result;
        }

        int IComparable<NameDescriptor>.CompareTo(NameDescriptor other)
        {
            return string.Compare(_name, other._name, true);
        }
    }
}