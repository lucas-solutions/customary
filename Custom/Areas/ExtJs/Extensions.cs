using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Areas.ExtJs
{
    using Custom.Areas.ExtJs.Models;
    using Custom.Objects;
    using Custom.Reflection;
    using Custom.Processes;

    public static class Extensions
    {
        public static ExtModel ExtModel(this ComplexDescriptor type)
        {
            List<ExtField> fields = new List<Models.ExtField>();
            List<ExtAssociation> associations = new List<ExtAssociation>();

            foreach (var property in type.Members.OfType<PropertyDescriptor>())
            {
                var field = new ExtField
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
                        var propertyType = ReflectionProcesses.Describe(property.PropertyType);
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

            return new ExtModel
            {
                Name = type.Name,
                Fields = fields,
                Associations = associations
            };
        }
    }
}