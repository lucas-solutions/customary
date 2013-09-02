using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Custom.Models
{
    using Custom.Extensions;

    internal class Metadata
    {
        public static implicit operator XDocument(Metadata metadata)
        {
            return metadata._x;
        }

        private readonly XDocument _x = new XDocument();

        public Metadata(Area area)
        {
            _x.Add(Edmx(area));
        }

        private XElement Edmx(Area area)
        {
            var edmx = new XElement(XName.Get("Edmx", "edmx"));

            edmx.Add(new XAttribute("Version", "1.0"));
            edmx.Add(new XAttribute(XName.Get("edmx", "xmlns"), "http://schemas.microsoft.com/ado/2007/06/edmx"));

            edmx.Add(EdmxDataServices(area));

            References(area).Each(edmx.Add);

            AnnotationsReferences(area).Each(edmx.Add);

            return edmx;
        }

        private XElement EdmxDataServices(Area area)
        {
            var dataServices = new XElement(XName.Get("DataServices", "edmx"));

            dataServices.Add(new XComment("Entity Data Model Conceptual Schemas, as specified in [MC-CSDL] and annotated as specified in [MS-ODATA]"));

            dataServices.Add(new Schema(area));

            dataServices.Add(new XComment("Additional Entity Data Model Conceptual Schemas as specified in [MC-CSDL] and annotated as specified in [MS-ODATA]"));

            return dataServices;
        }

        private IEnumerable<XElement> References(Area area)
        {
            //<edmx:Reference Url=”http://www.fabrikam.com/model.edmx” />
            //<edmx:Reference Url=”http://www.fabrikam.com/model.csdl” />

            return new XElement[] { };
        }

        private IEnumerable<XElement> AnnotationsReferences(Area area)
        {
            /*
             * <edmx:AnnotationsReference Url=”http://fabrikam.com/Annotations.edmx”>
<edmx:Include TermNamespace=”Com.Fabrikam.Model” Qualifier=”Phone” />
</edmx:AnnotationsReference>
<edmx:AnnotationsReference Url=”http://fabrikam.com/Annotations.edmx”>
<edmx:Include TermNamespace=”Com.Fabrikam.Model” />
</edmx:AnnotationsReference>
<edmx:AnnotationsReference Url=”http://fabrikam.com/Annotations.edmx”>
<edmx:Include Qualifier=”Phone” />
</edmx:AnnotationsReference>
<edmx:AnnotationsReference Url=”http://fabrikam.com/Annotations.edmx”>
<edmx:Include />
</edmx:AnnotationsReference>
             */

            return new XElement[] { };
        }
    }
}
