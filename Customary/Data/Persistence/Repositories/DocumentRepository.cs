using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Data.Persistence.Repositories
{
    using Custom.Data.Metadata;
    using Raven.Abstractions.Data;
    using Raven.Imports.Newtonsoft.Json.Linq;
    using Raven.Json.Linq;

    public class DocumentRepository : IRavenJObjectRepository
    {
        private readonly ModelDescriptor _descriptor;
        private readonly DocumentContext _context;

        public DocumentRepository(ModelDescriptor descriptor, DocumentContext context)
        {
            _descriptor = descriptor;
            _context = context;
        }

        public DocumentContext Context
        {
            get { return _context; }
        }

        public RavenJObject Read(int skip, int take)
        {
            var result = new RavenJObject();

            try
            {
                var data = _context.Session.Advanced.LoadStartingWith<RavenJObject>(_descriptor.KeyPrefix, null, skip, take);

                foreach (var entity in data)
                {
                    var key = _context.Session.Advanced.GetDocumentId(entity);
                    var type = _descriptor.Path;
                    var typeName = string.Join("/", key.Split('/').Reverse().Skip(1).Reverse().Last());

                    if (!type.EndsWith(typeName))
                    {
                        var path = string.Join("/", _descriptor.Path.Split('/').Reverse().Skip(1).Reverse());
                        type = string.IsNullOrEmpty(path) ? typeName : path + '/' + typeName;
                    }

                    entity["$key"] = key;
                    entity["$type"] = new RavenJValue(type);

                    Guid id;
                    if (Guid.TryParse(key.Split('/').Last(), out id))
                    {
                        entity["Id"] = new RavenJValue(id);
                    }
                }

                result["success"] = new RavenJValue(true);
                result["data"] = new RavenJArray(data.AsEnumerable<RavenJToken>());
            }
            catch (Exception e)
            {
                result["success"] = new RavenJValue(false);
                result["message"] = new RavenJValue(e.Message);
            }

            return result;
        }

        public RavenJObject Read(Guid id)
        {
            var result = new RavenJObject();

            try
            {
                var keyPrefix = _descriptor.KeyPrefix;
                var key = string.Concat(keyPrefix, id);
                var data = _context.Session.Load<RavenJObject>(key);

                if (data != null)
                {
                    result["success"] = new RavenJValue(true);
                    result["data"] = data;
                    data["Id"] = new RavenJValue(id);
                }
                else
                {
                    result["success"] = new RavenJValue(false);
                    result["message"] = string.Format("Document with key \"{0}\" not found at store {1} (key prefix: \"{2}\", id: {3})", key, _context.Name, keyPrefix, id);
                }
            }
            catch (Exception e)
            {
                result["success"] = new RavenJValue(false);
                result["message"] = new RavenJValue(e.Message);
            }

            return result;
        }

        public RavenJObject Create(RavenJObject value)
        {
            var result = new RavenJObject();

            try
            {
                var id = Guid.NewGuid();
                var key = _descriptor.KeyPrefix + id.ToString("D");

                value["id"] = new RavenJValue(id);

                _context.Session.Store(value, key);

                result["success"] = new RavenJValue(true);
                result["data"] = value;
            }
            catch (Exception e)
            {
                result["success"] = new RavenJValue(false);
                result["message"] = new RavenJValue(e.Message);
            }

            return result;
        }

        public RavenJObject Update(Guid id, RavenJObject value, bool patch)
        {
            var result = new RavenJObject();

            try
            {
                var key = _descriptor.KeyPrefix + id.ToString("D");

                if (patch)
                {
                    var current = _context.Session.Load<RavenJObject>(key);

                    patch = current != null;

                    if (patch)
                    {
                        current.Merge(value, _descriptor.Definition);
                        _context.Session.Store(current, key);
                        value = current;
                    }
                }

                if (!patch)
                {
                    _context.Session.Store(value, key);
                }

                value["id"] = new RavenJValue(id);

                result["success"] = new RavenJValue(true);
                result["data"] = value;
            }
            catch (Exception e)
            {
                result["success"] = new RavenJValue(false);
                result["message"] = new RavenJValue(e.Message);
            }

            return result;
        }

        public RavenJObject Delete(Guid id)
        {
            var result = new RavenJObject();

            try
            {
                var key = _descriptor.KeyPrefix + id.ToString("D");

                var current = _context.Session.Load<RavenJObject>(key);

                if (current != null)
                {
                    _context.Session.Delete(current);
                    _context.Session.SaveChanges();
                }
                else
                {
                    result["message"] = new RavenJValue("Not found");
                }

                result["success"] = new RavenJValue(true);
            }
            catch (Exception e)
            {
                result["success"] = new RavenJValue(false);
                result["message"] = new RavenJValue(e.Message);
            }

            return result;
        }

        public RavenJObject Delete(RavenJObject entity)
        {
            var result = new RavenJObject();

            try
            {
                var key = _descriptor.KeyPrefix + entity["Id"];

                var current = _context.Session.Load<RavenJObject>(key);

                if (current != null)
                {
                    _context.Session.Delete(current);
                    _context.Session.SaveChanges();
                }
                else
                {
                    result["message"] = new RavenJValue("Not found");
                }

                result["success"] = new RavenJValue(true);
            }
            catch (Exception e)
            {
                result["success"] = new RavenJValue(false);
                result["message"] = new RavenJValue(e.Message);
            }

            return result;
        }

        public RavenJObject Delete(RavenJArray data)
        {
            var result = new RavenJObject();

            try
            {
                foreach (var item in data)
                {
                    string id;

                    switch (item.Type)
                    {
                        case JTokenType.Guid:
                            id = item.Value<Guid>().ToString("D");
                            break;

                        case JTokenType.String:
                            id = item.Value<string>();
                            break;

                        case JTokenType.Object:
                            id = item.Value<String>("Id");
                            break;

                        default:
                            continue;
                    }

                    var key = _descriptor.KeyPrefix + id;

                    var current = _context.Session.Load<RavenJObject>(key);

                    if (current != null)
                    {
                        _context.Session.Delete(current);
                    }
                }

                _context.Session.SaveChanges();

                result["success"] = new RavenJValue(true);
            }
            catch (Exception e)
            {
                result["success"] = new RavenJValue(false);
                result["message"] = new RavenJValue(e.Message);
            }

            return result;
        }


        public RavenJObject Create(RavenJArray data)
        {
            throw new NotImplementedException();
        }

        public RavenJObject Update(RavenJObject entity, bool patch)
        {
            var idValue = entity.Value<string>("Id");

            Guid id;
            if (Guid.TryParse(idValue, out id))
            {
                return Update(id, entity, patch);
            }

            var result = new RavenJObject();

            result["success"] = new RavenJValue(false);
            result["message"] = "Id not included in URL nor in body";

            return result;
        }

        public RavenJObject Update(RavenJArray data, bool patch)
        {
            var result = new RavenJObject();

            var prefix = _descriptor.KeyPrefix;

            for (int i = 0, count = data.Length; i < count; i++)
            {
                var value = data[i];

                Guid id;

                if (value.Type == JTokenType.Null)
                {
                    continue;
                }

                if (value.Type != JTokenType.Object)
                {
                    result["success"] = new RavenJValue(false);
                    result["message"] = new RavenJValue(string.Format("Enty at position {0} is not an object", i));

                }
                else if (Guid.TryParse(value.Value<string>("Id"), out id))
                {
                    var key = prefix + id.ToString("D");
                    var entity = value as RavenJObject;

                    if (patch)
                    {
                        var current = _context.Session.Load<RavenJObject>(key);

                        patch = current != null;

                        if (patch)
                        {
                            Patch(key, current, entity, _descriptor.Definition);
                            //current.Merge(entity, _descriptor.Definition);
                            //_context.Session.Store(current, key);
                            entity = current;
                        }
                    }

                    if (!patch)
                    {
                        _context.Session.Store(entity, key);
                    }

                    result["success"] = new RavenJValue(true);
                }
                else
                {
                    result["success"] = new RavenJValue(false);
                    result["message"] = new RavenJValue(string.Format("Enty at position {0} Id did not parse to an Guid ({1})", i, value.Value<string>("Id")));
                }
            }

            return result;
        }

        private RavenJObject Patch(string key, RavenJObject target, RavenJObject source, ModelDefinition model)
        {
            RavenJObject result = null;

            List<PatchRequest> patches = new List<PatchRequest>();

            foreach (var entry in source)
            {
                var property = model.Properties.FirstOrDefault(o => o.Name == entry.Key);

                if (property == null)
                {
                    // error: property not in metadata
                    continue;
                }

                var nd = DataDictionary.Current.Describe(property.Type);

                if (nd == null)
                {
                    // error: property type not defined
                    continue;
                }

                if (nd.Type != NodeKinds.Type)
                {
                    // error: property type is not a type
                    continue;
                }

                var td = nd as TypeDescriptor;

                switch (td.Category)
                {
                    case TypeCategories.Enum:
                        patches.Add(new PatchRequest
                        {
                            Type = PatchCommandType.Set,
                            Name = property.Name,
                            Value = entry.Value
                        });
                        break;

                    case TypeCategories.Model:
                        var md = td as ModelDescriptor;
                        if (!PropertyRoles.HasMany.Equals(property.Role & PropertyRoles.HasMany))
                        {
                            patches.Add(new PatchRequest
                            {
                                Type = PatchCommandType.Modify,
                                Name = property.Name,
                                Value = entry.Value
                            });
                        }
                        else if (entry.Value.Type == JTokenType.Array)
                        {
                            patches.Add(new PatchRequest
                            {
                                Type = PatchCommandType.Set,
                                Name = property.Name,
                                Value = source
                            });
                        }
                        else if (entry.Value.Type == JTokenType.Object)
                        {
                            var dest = target.Value<RavenJArray>(entry.Key);

                            if (dest != null)
                            {
                                Patch(dest, entry.Value as RavenJObject, property, patches);
                            }
                            else
                            {
                                var dictionary = entry.Value as RavenJObject;
                                var array = new RavenJArray();
                                foreach (var o in dictionary)
                                {
                                    array.Add(o.Value);
                                }
                                patches.Add(new PatchRequest
                                {
                                    Type = PatchCommandType.Set,
                                    Name = property.Name,
                                    Value = array
                                });
                            }
                        }
                        break;

                    case TypeCategories.Unit:
                        patches.Add(new PatchRequest
                        {
                            Type = PatchCommandType.Set,
                            Name = property.Name,
                            Value = entry.Value
                        });
                        break;

                    case TypeCategories.Value:
                        patches.Add(new PatchRequest
                        {
                            Type = PatchCommandType.Set,
                            Name = property.Name,
                            Value = entry.Value
                        });
                        break;

                    default:
                        // error: type category not defined
                        break;
                }
            }

            _context.Store.DatabaseCommands.Patch(key, patches.ToArray());

            return result;
        }

        private RavenJArray Patch(RavenJArray target, RavenJObject source, PropertyDefinition property, List<PatchRequest> patch)
        {
            RavenJArray result = null;

            var idProperty = property.IdProperty;
            var dictionary = source as RavenJObject;

            foreach (var entry in dictionary)
            {
                int? position = null;
                for (int i = 0, count = target.Length; i < count; i++)
                {
                    if (target[i] == null || target[i].Type == JTokenType.Null)
                    {
                        continue;
                    }
                    var value = target[i].Value<RavenJValue>(idProperty);
                    if (string.Equals(value.Value, entry.Key))
                    {
                        position = i;
                        break;
                    }
                }

                if (position.HasValue)
                {
                    patch.Add(new PatchRequest
                    {
                        Type = PatchCommandType.Remove,
                        Name = property.Name,
                        Position = position.Value
                    });

                    var merge = target[position.Value] as RavenJObject;

                    switch (entry.Value.Type)
                    {
                        case JTokenType.Null:
                            break;

                        case JTokenType.Object:
                            foreach (var v in entry.Value as RavenJObject)
                            {
                                merge[v.Key] = v.Value;
                            }

                            patch.Add(new PatchRequest
                            {
                                Type = PatchCommandType.Add,
                                Name = property.Name,
                                Value = merge
                            });
                            break;

                        default:
                            // error
                            break;
                    }
                }
                else
                {
                    patch.Add(new PatchRequest
                    {
                        Type = PatchCommandType.Add,
                        Name = property.Name,
                        Value = entry.Value
                    });
                }
            }

            return result;
        }
    }
}