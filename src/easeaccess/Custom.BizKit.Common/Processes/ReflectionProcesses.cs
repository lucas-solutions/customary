using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Processes
{
    using Custom.Extensions;
    using Custom.Models;
    using Custom.Repositories;
    using Custom.Transforms;
    using Custom.Utils;
    using Raven.Abstractions.Data;
    using Raven.Imports.Newtonsoft.Json.Linq;
    using Raven.Json.Linq;

    public class ReflectionProcesses<T> : IDisposable where T : class, new()
    {
        private readonly Reflection _reflection;
        private readonly RavenJObject _data;

        public ReflectionProcesses(Reflection reflection)
        {
            _reflection = reflection;
            _data = null;
        }

        public ReflectionProcesses(Reflection reflection, RavenJObject data)
        {
            _reflection = reflection;
            _data = data;
        }

        public void Modify(RavenJToken token, T entity, bool ignoreNull)
        {
            switch (token.Type)
            {
                case JTokenType.Object:
                    var properties = typeof(T).GetProperties(
                        System.Reflection.BindingFlags.Public |
                        System.Reflection.BindingFlags.Instance);
                    var source = (token as RavenJObject);
                    foreach (var prop in properties)
                    {
                        RavenJToken value;
                        if (source.TryGetValue(prop.Name, out value))
                        {
                            switch (value.Type)
                            {
                                case JTokenType.Object:
                                    break;

                                default:
                                    if (!ignoreNull || value.Type != JTokenType.Null)
                                    {
                                        var val = Convert.ChangeType(value.ToString(), prop.PropertyType);
                                        prop.SetValue(entity, val);
                                    }
                                    break;
                            }
                        }
                    }
                    break;
            }
        }

        public virtual ProcessResult Get<T>(List<T> collection, int start, int limit, Transform<T> transform)
        {
            var query = collection.Skip(start);

            if (limit > 0)
                query = query.Take(limit);

            var data = transform != null ? query.Select(o => transform(o)).ToArray() : (Array)query.ToArray();

            return new ProcessResult { success = true, data = data };
        }

        public virtual ProcessResult Clear(List<T> collection)
        {
            if (collection != null)
            {
                collection.Clear();

                return new ProcessResult { success = true };
            }

            return new ProcessResult { success = false };
        }

        public virtual ProcessResult CopyTo<T>(List<T> collection) where T : class
        {
            T item = null;
            Uri target = null;

            if (collection != null && item != null && target != null)
            {
            }

            return new ProcessResult { success = false };
        }

        public virtual ProcessResult Insert(List<T> collection, Func<T, bool> exists)
        {
            if (collection == null)
                return new ProcessResult { success = false, message = "Invalid request" };

            var messages = new List<string>();

            _data.Each<T>((RavenJTokenCallbackModel<T> model) =>
            {
                if (exists(model.Value))
                {
                }
                else if (model.Position.HasValue)
                {
                    collection.Insert(model.Position.Value, model.Value);
                }
                else
                {
                    collection.Add(model.Value);
                }

                _reflection.SaveChanges();

                return true;
            });

            string message = null;

            switch (messages.Count)
            {
                case 0:
                    break;
                case 1:
                    message = messages.First();
                    break;
                default:
                    message = messages.ToHtmlList();
                    break;
            }

            return new ProcessResult { success = true, message = message };
        }

        public virtual ProcessResult MoveTo<T>(List<T> collection) where T : class
        {
            T item = null;
            Uri target = null;

            if (collection != null && item != null && target != null)
            {
            }

            return new ProcessResult { success = false };
        }

        public virtual ProcessResult Remove<T>(List<T> collection, Func<T, string, bool> byId) where T : class
        {
            if (collection == null)
                return new ProcessResult { success = false, message = "Invalid request" };

            var success = false;
            var messages = new List<string>();

            if (_data.Each((RavenJTokenCallbackModel model) =>
            {
                if (String.IsNullOrEmpty(model.Id))
                {
                    messages.Add(string.Format("Item at position {0} had id property missing." + model.Index));
                    return true;
                }

                var entity = collection.SingleOrDefault(o => byId(o, model.Id));

                if (entity == null)
                {
                    messages.Add(string.Format("Item at position {0} with id {1} was not found.", model.Index, model.Id));
                    return true;
                }

                if (!collection.Remove(entity))
                {
                    messages.Add(string.Format("Item at position {0} with id {1} could not be removed.", model.Index, model.Id));

                    return true;
                }

                return true;
            }))
            {
                _reflection.SaveChanges();
                success = true;
            }

            string message = null;

            switch (messages.Count)
            {
                case 0:
                    break;
                case 1:
                    message = messages.First();
                    break;
                default:
                    message = messages.ToHtmlList();
                    break;
            }

            return new ProcessResult { success = success, message = message };
        }

        public virtual ProcessResult Update(List<T> collection, Func<T, string, bool> byId)
        {
            if (collection == null)
                return new ProcessResult { success = false, message = "Invalid request" };

            var messages = new List<string>();

            _data.Each((RavenJTokenCallbackModel model) =>
            {
                if (model.Id == null)
                {
                    messages.Add(string.Format("Item at position {0} disn't provide id.", model.Index));
                    return true;
                }

                var entity = collection.SingleOrDefault(o => byId(o, model.Id));

                if (entity == null)
                {
                    messages.Add(string.Format("Item at position {0} with id {1} was not found.", model.Index, model.Id));

                    return false;
                }

                Modify(model.Token, entity, true);

                _reflection.SaveChanges();

                return true;
            });

            string message = null;

            switch (messages.Count)
            {
                case 0:
                    break;
                case 1:
                    message = messages.First();
                    break;
                default:
                    message = messages.ToHtmlList();
                    break;
            }

            return new ProcessResult { success = true, message = message };
        }


        /*private object Patch(PatchCommandType type, string name = null, int? position = null, RavenJToken value = null)
        {
            if (_patchList.Count.Equals(0))
                return new { success = false, code = "404", message = "Not found" };

            var endPoint = _patchList.Last();
            endPoint.Type = type;
            endPoint.Name = name;
            endPoint.Position = position;
            endPoint.Value = value;

            try
            {
                NoSql.DocumentStore.Instance.DatabaseCommands.Patch(_id, new[] { _patchList.First() });
            }
            catch (Exception e)
            {
                return new { success = false, code = "400", message = "Bad request. " + e.Message };
            }

            return true;
        }

        private static object Patch(PatchCommandType type, string name = null, int? position = null, RavenJToken value = null)
        {
            if (_patchList.Count.Equals(0))
                return new { success = false, code = "404", message = "Not found" };

            var endPoint = _patchList.Last();
            endPoint.Type = type;
            endPoint.Name = name;
            endPoint.Position = position;
            endPoint.Value = value;

            try
            {
                NoSql.DocumentStore.Instance.DatabaseCommands.Patch(_id, new[] { _patchList.First() });
            }
            catch (Exception e)
            {
                return new { success = false, code = "400", message = "Bad request. " + e.Message };
            }

            return true;
        }

        public static object Patch(PatchRequest[] request)
        {
            if (_patchList.Count.Equals(0))
                return new { success = false, code = "404", message = "Not found" };

            _patchList.Last().Nested = request;

            try
            {
                NoSql.DocumentStore.Instance.DatabaseCommands.Patch(_id, new[] { _patchList.First() });
            }
            catch (Exception e)
            {
                return new { success = false, code = "400", message = "Bad request. " + e.Message };
            }
            finally
            {
                _patchList.Last().Nested = null;
            }

            return new { success = true };
        }*/

        public void Dispose()
        {
        }
    }
}
