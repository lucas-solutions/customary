using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Data.Persistence
{
    using Custom.Data.Metadata;
    using Raven.Json.Linq;

    public class RavenDocumentRepository : IRavenJObjectRepository
    {
        private readonly EntityDefinition _definition;
        private readonly RavenDocumentCatalog _catalog;
        private readonly string _keyPrefix;

        private EntityDefinition[] _ancestors;

        public RavenDocumentRepository(EntityDefinition definition, RavenDocumentCatalog catalog)
        {
            _definition = definition;
            _catalog = catalog;
            _keyPrefix = definition.GetEntityName() + '/';

            var ancestors = new List<EntityDefinition>();

            for (var o = definition.GetParentDefinition(); o != null; o = o.GetParentDefinition())
                ancestors.Add(o);

            _ancestors = ancestors.ToArray();

            if (ancestors.Count > 0)
                _keyPrefix = _ancestors.Last().GetEntityName() + '/' + _keyPrefix;
        }

        public RavenDocumentCatalog Catalog
        {
            get { return _catalog; }
        }

        public RavenJObject Read(int skip, int take)
        {
            var result = new RavenJObject();

            try
            {
                var data = _catalog.Session.Advanced.LoadStartingWith<RavenJObject>(_keyPrefix, null, skip, take);

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
                var data = _catalog.Session.Load<RavenJObject>(_keyPrefix + id.ToString("N"));

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
                var key = _keyPrefix + id.ToString("N");

                value["id"] = new RavenJValue(id);

                _catalog.Session.Store(value, key);

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

        public RavenJObject Update(Guid id, RavenJObject value)
        {
            var result = new RavenJObject();

            try
            {
                var key = _keyPrefix + id.ToString("N");

                value["id"] = new RavenJValue(id);

                _catalog.Session.Store(value, key);

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

        public RavenJObject Patch(Guid id, RavenJObject value)
        {
            var result = new RavenJObject();

            try
            {
                var key = _keyPrefix + id.ToString("N");

                var current = _catalog.Session.Load<RavenJObject>(key);

                if (current != null)
                {
                    current.Merge(value, _definition);
                    _catalog.Session.Store(current, key);
                    value = current;
                }
                else
                {   
                    _catalog.Session.Store(value, key);
                }

                value["id"] = new RavenJValue(id);

                _catalog.Session.SaveChanges();

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
                var key = _keyPrefix + id.ToString("N");

                var current = _catalog.Session.Load<RavenJObject>(key);

                if (current != null)
                {
                    _catalog.Session.Delete(current);
                    _catalog.Session.SaveChanges();
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

        IRavenJObjectCatalog IRavenJObjectRepository.Store
        {
            get { return Catalog; }
        }
    }
}