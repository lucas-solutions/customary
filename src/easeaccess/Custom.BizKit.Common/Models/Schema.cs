using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Custom.Models
{
    using Custom.Extensions;

    internal class Schema
    {
        public static implicit operator XElement(Schema schema)
        {
            return schema._x;
        }

        private class Relationship
        {
            public Relationship(Column a, Grid m)
            {
            }

            public Column Dependant
            {
                get { return null; }
            }

            public string Name
            {
                get { return null; }
            }

            public Column Principal
            {
                get { return null; }
            }
        }

        private readonly XElement _x = new XElement("Schema");
        private readonly string _namespace;
        private readonly List<Relationship> _relationships;
        
        public Schema(Area area)
        {
            _relationships = area.Grids
                .SelectMany(o => o.Columns.Select(x => new Relationship(x, o)))
                .ToList();

            _namespace = "Custom";
            _x.Add(new XAttribute("Namespace", _namespace));
            _x.Add(EntityContainer(area));

            area.Grids.Select(o => EntityType(o)).Each(_x.Add);
            _relationships.Select(o => Association(o)).Each(_x.Add);
        }

        private XElement Association(Relationship relationship)
        {
            var x = new XElement("Association");
            x.Add(new XAttribute("Name", relationship.Name));
            x.Add(ReferentialConstraint(relationship));
            return x;
        }

        private XElement AssociationSet(Relationship relationship)
        {
            var x = new XElement("AssociationSet");
            x.Add(new XAttribute("Name", relationship.Name));
            x.Add(new XAttribute("Association", _namespace + '.' + relationship.Name));
            x.Add(End(relationship.Principal));
            x.Add(End(relationship.Dependant));
            return x;
        }

        private XElement Dependent(Column property)
        {
            var x = new XElement("Dependent");
            x.Add(new XAttribute("Role", ""));
            x.Add(PropertyRef(property));
            return x;
        }

        private XElement End(Column property)
        {
            var x = new XElement("End");
            x.Add(new XAttribute("Role", ""));
            x.Add(new XAttribute("Type", ""));
            x.Add(new XAttribute("Multiplicity", ""));
            x.Add(PropertyRef(property));
            return x;
        }

        private XElement EntityContainer(Area area)
        {
            var x = new XElement("EntityContainer");
            x.Add(new XAttribute("Name", area.Name + "Entities"));
            x.Add(new XAttribute(XName.Get("IsDefaultEntityContainer", "m"), "true"));
            EntitySets(area).Each(x.Add);
            _relationships.Select(o => AssociationSet(o)).Each(_x.Add);
            return x;
        }

        private IEnumerable<XElement> EntitySets(Area area)
        {
            return new XElement[] { };
        }

        private XElement EntityType(Grid model)
        {
            var entityType = new XElement("EntityType");
            entityType.Add(Key(model));
            return entityType;
        }

        private XElement Key(Grid model)
        {
            var key = new XElement("Key");
            key.Add(PropertyRef(new Column { Name = "Id" }));
            return key;
        }

        private XElement NavigationProperty(Column property)
        {
            var x = new XElement("NavigationProperty");
            x.Add(new XAttribute("Name", property.Name));
            x.Add(new XAttribute("Relationship", ""));
            x.Add(new XAttribute("FromRole", ""));
            x.Add(new XAttribute("ToRole", ""));
            return x;
        }

        private XElement Principal(Column property)
        {
            var x = new XElement("Principal");
            x.Add(PropertyRef(property));
            return x;
        }

        private IEnumerable<XElement> Properties(Grid model)
        {
            return model.Columns.Select(o => Property(o));
        }

        private XElement Property(Column property)
        {
            var x = new XElement("Property");
            x.Add(new XAttribute("Name", property.Name));
            //x.Add(new XAttribute("Type", "Edm." + property.Type));
            x.Add(new XAttribute("Nullable", "true"));
            x.Add(new XAttribute("MaxLength", "5"));
            x.Add(new XAttribute("Precision", "19"));
            return x;
        }

        private XElement PropertyRef(Column property)
        {
            var propertyRef = new XElement("PropertyRef");

            propertyRef.Add(new XAttribute("Name", property.Name));

            return propertyRef;
        }

        private XElement ReferentialConstraint(Relationship relationship)
        {
            var x = new XElement("ReferentialConstraint");
            x.Add(Principal(relationship.Principal));
            x.Add(Dependent(relationship.Dependant));
            return x;
        }
    }
}
