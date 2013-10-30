using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Data.Persistence.Repositories
{
    using Custom.Data.Metadata;
    using Raven.Json.Linq;

    public class SingletonRepository : IRavenJObjectRepository
    {
        private readonly ModelDefinition _definition;
        private readonly DocumentContext _context;
        private readonly ModelDefinition[] _ancestors;
        private readonly string _key;

        public SingletonRepository(ModelDefinition definition, DocumentContext context)
        {
            _definition = definition;
            _context = context;

            _key = definition.Name;
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
                var data = new RavenJArray();

                var value = _context.Session.Load<RavenJObject>(_key);

                data.Add(value);

                result["success"] = new RavenJValue(true);
                result["data"] = data;
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
                var data = _context.Session.Load<RavenJObject>(_key + id.ToString("N"));

                result["success"] = new RavenJValue(true);
                result["data"] = data;
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
                var key = _key + id.ToString("N");

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
                var key = _key + id.ToString("N");

                if (patch)
                {
                    var current = _context.Session.Load<RavenJObject>(key);

                    patch = current != null;

                    if (patch)
                    {
                        current.Merge(value, _definition);
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
                var key = _key + id.ToString("N");

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
    }
}