using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Data.Persistence.Repositories
{
    using Custom.Data.Metadata;
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
                var key = _descriptor.KeyPrefix + id.ToString("D");
                var data = _context.Session.Load<RavenJObject>(key);

                if (data != null)
                {
                    result["success"] = new RavenJValue(true);
                    result["data"] = data;
                }
                else
                {
                    result["success"] = new RavenJValue(false);
                    result["message"] = string.Format("Document {0} not found at store {1}", key, _context.Name);
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
    }
}