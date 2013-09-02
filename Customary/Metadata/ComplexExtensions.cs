using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Metadata
{
    using Custom.Models.Ext;
    using Custom.Metadata;

    public static class ComplexExtensions
    {
        public static ModelViewModel Model(this ComplexDescriptor type)
        {
            List<FieldViewModel> fields = new List<FieldViewModel>();
            List<AssociationViewModel> associations = new List<AssociationViewModel>();

            foreach (var property in type.Members.OfType<PropertyDescriptor>())
            {
                var field = new FieldViewModel
                {
                    Name = property.Name,
                };

                fields.Add(field);

                switch (property.PropertyType)
                {
                    case "String":
                        field.Type = "text";
                        break;

                    default:
                        var propertyType = Global.Metadata.Describe(property.PropertyType);
                        if (propertyType != null)
                        {
                            switch (propertyType.MemberType)
                            {
                                case MemberTypes.Primitive:
                                    break;

                                case MemberTypes.Entity:
                                    var foreignKey = propertyType.Members.OfType<PropertyDescriptor>().SingleOrDefault(o => o.Role == PropertyRoles.Identity);
                                    break;
                            }
                        }
                        field.Type = "text";
                        /*'belongsTo',
                    type: 'hasOne',
                    type: 'hasOne',
                    type: 'hasMany',*/
                        break;
                }
            }

            return new ModelViewModel
            {
                //Name = type.Name,
                //Fields = fields,
                Associations = associations
            };
        }
    }
}