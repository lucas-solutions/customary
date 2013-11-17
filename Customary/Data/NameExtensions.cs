using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Custom.Data
{
    using Custom.Data.Metadata;

    public static class NameExtensions
    {
        #region - edmx -

        public static XElement Edmx(this NameDescriptor descriptor)
        {
            var x = new XElement(XName.Get("Edmx", "edmx"));

            x.Add(new XAttribute(XName.Get("edmx", "edmx"), "http://schemas.microsoft.com/ado/2007/06/edmx"));
            x.Add(new XAttribute("Version", "1.0"));

            x.Add(DataServices(descriptor));

            return x;
        }

        public static XElement DataServices(this NameDescriptor descriptor)
        {
            var x = new XElement(XName.Get("DataServices", "edmx"));

            x.Add(new XAttribute(XName.Get("m", "xmlns"), "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata"));
            x.Add(new XAttribute(XName.Get("DataServiceVersion", "m"), "3.0"));
            x.Add(new XAttribute(XName.Get("MaxDataServiceVersion", "m"), "3.0"));

            x.Add(Schema(descriptor));

            return x;
        }

        public static XElement Schema(this NameDescriptor descriptor)
        {
            var ns = descriptor.Name.Replace("/", ".");

            var x = new XElement("Schema");

            x.Add(new XAttribute("xmlns", "http://schemas.microsoft.com/ado/2009/11/edm"));
            x.Add(new XAttribute("Namespace", ns));

            var annotations = new List<XElement>();
            var entityTypes = new List<XElement>();
            var complexTypes = new List<XElement>();
            var associations = new List<XElement>();
            var associationSets = new List<XElement>();
            var entitySets = new List<XElement>();
            var functionImports = new List<XElement>();

            switch (descriptor.Type)
            {
                case NodeKinds.Area:
                case NodeKinds.Name:
                    foreach (var item in descriptor.Items)
                    {
                        if (item.Type != NodeKinds.Type)
                        {
                            var type = item as TypeDescriptor;

                            switch (type.Category)
                            {
                                case TypeCategories.Enum:
                                    {
                                    }
                                    break;

                                case TypeCategories.Model:
                                    {
                                    }
                                    break;

                                case TypeCategories.Unit:
                                    {
                                    }
                                    break;

                                case TypeCategories.Value:
                                    {
                                    }
                                    break;
                            }

                            continue;
                        }
                    }
                    break;

                case NodeKinds.Type:
                    break;
            }

            foreach (var e in entityTypes)
            {
                x.Add(e);
            }

            foreach (var e in complexTypes)
            {
                x.Add(e);
            }

            foreach (var e in associations)
            {
                x.Add(e);
            }

            var serviceName = descriptor.Name.Split('/').Last();

            var c = EntityContainer(serviceName);

            foreach (var e in entitySets)
            {
                c.Add(e);
            }

            foreach (var e in functionImports)
            {
                c.Add(e);
            }

            foreach (var e in associationSets)
            {
                c.Add(e);
            }

            foreach (var e in annotations)
            {
                x.Add(e);
            }

            x.Add(EntityContainerAnnotations(serviceName, ns, ""));

            x.Add(EntityContainerSuppliersAnnotations(serviceName, ns));

            return x;
        }

        private static XElement EntityContainer(string serviceName)
        {
            var x = new XElement("EntityContainer");

            x.Add(new XAttribute("Name", serviceName));
            x.Add(new XAttribute(XName.Get("IsDefaultEntityContainer", "m"), "true"));

            return x;
        }

        private static XElement EntityContainerAnnotations(string serviceName, string ns, string summary)
        {
            var x = new XElement("Annotations");

            x.Add(new XAttribute("Target", ns + "." + serviceName));

            x.Add(ValueAnnotation("Org.OData.Display.V1.Description", summary));

            return x;
        }

        private static XElement EntityContainerSuppliersAnnotations(string serviceName, string ns)
        {
            var x = new XElement("Annotations");

            x.Add(new XAttribute("Target", ns + "." + serviceName + "/Suppliers"));

            x.Add(ValueAnnotation("Org.OData.Publication.V1.PublisherName", "Microsoft Corp."));
            x.Add(ValueAnnotation("Org.OData.Publication.V1.PublisherId", "MSFT"));
            x.Add(ValueAnnotation("Org.OData.Publication.V1.Keywords", "Inventory, Supplier, Advertisers, Sales, Finance"));
            x.Add(ValueAnnotation("Org.OData.Publication.V1.AttributionUrl", "Microsoft Corp."));
            x.Add(ValueAnnotation("Org.OData.Publication.V1.AttributionDescription", "http://www.odata.org/"));
            x.Add(ValueAnnotation("Org.OData.Publication.V1.DocumentationUrl", "http://www.odata.org/"));
            x.Add(ValueAnnotation("Org.OData.Publication.V1.TermsOfUseUrl", "All rights reserved"));
            x.Add(ValueAnnotation("Org.OData.Publication.V1.PrivacyPolicyUrl", "http://www.odata.org"));
            x.Add(ValueAnnotation("Org.OData.Publication.V1.LastModified", "4/2/2013"));
            x.Add(ValueAnnotation("Org.OData.Publication.V1.ImageUrl", "http://www.odata.org/"));

            return x;
        }

        private static XElement Complex(ModelDescriptor descriptor)
        {
            return null;
        }

        private static XElement Complex(UnitDescriptor descriptor)
        {
            return null;
        }

        private static XElement EntityType(ModelDescriptor descriptor)
        {
            var x = new XElement("EntityType");

            x.Add(new XAttribute("Name", descriptor.Name));

            var definition = descriptor.Definition;

            for (var source = descriptor; descriptor != null; descriptor = descriptor.BaseType as ModelDescriptor)
            {
                if (descriptor.Definition.Embeddable)
                {
                    break;
                }

                EntityType(x, source.Definition);
            }

            return x;
        }

        private static void EntityType(XElement x, ModelDefinition definition)
        {
            for (var i = 0; i < definition.Properties.Count; i++)
            {
                var property = definition.Properties[i];

                XElement xProperty;

                xProperty = new XElement("Property");

                xProperty.Add(new XAttribute("Name", property.Name));
                xProperty.Add(new XAttribute("Type", property.Type));

                x.Add(xProperty);
            }
        }

        private static XElement Enum(EnumDescriptor descriptor)
        {
            return null;
        }

        private static XElement Facet(ValueDescriptor descriptor)
        {
            return null;
        }

        private static XElement ValueAnnotation(string term, string str)
        {
            var x = new XElement("ValueAnnotation");

            x.Add(new XAttribute("Term", term));
            x.Add(new XAttribute("String", str));

            return x;
        }

        #endregion - edmx -

        #region - json schema -

        #endregion
    }
}