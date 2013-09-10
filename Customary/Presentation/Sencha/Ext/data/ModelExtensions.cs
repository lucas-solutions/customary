using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.Ext.data
{
    using Custom.Metadata;

    public static class ModelExtensions
    {
        public static IEnumerable<Ext.data.Validation> EnumValidations(this PropertyDescriptor property)
        {
            return null;
        }

        public static Ext.data.Association ToAssociation(this PropertyDescriptor property)
        {
            return null;
        }

        public static Ext.data.Field ToField(this PropertyDescriptor property)
        {
            var builder = new Field.Builder();

            return builder.ToModel();
        }

        public static Ext.data.Model ToModel(this EntityDescriptor entity)
        {
            var builder = new Model.Builder();

            builder
                .Name(entity.Namespace + '.' + entity.Name)
                .Proxy(proxy =>
                {

                })
                .Fields(collection =>
                {

                })
                .Associations(collection =>
                {
                })
                .Validations(collection =>
                {
                });

            entity.Members.ForEach(member =>
                {
                    // Only properties
                    if (member.MemberType != MemberTypes.Property)
                        return;

                    var property = member as PropertyDescriptor;

                    Debug.Assert(property != null);

                    var type = Global.Metadata.Describe(property.PropertyType);

                    if (type == null)
                    {
                    }

                    switch (type.MemberType)
                    {
                        case MemberTypes.Primitive:
                            builder.Fields(collection => collection.Add(property.ToField()));
                            builder.Validations(collection => collection.Add(property.EnumValidations()));
                            break;

                        case MemberTypes.Enum:
                            builder.Fields(collection => collection.Add(property.ToField()));
                            builder.Validations(collection => collection.Add(property.EnumValidations()));
                            break;

                        case MemberTypes.Unit:
                            builder.Fields(collection => collection.Add(property.ToField()));
                            builder.Validations(collection => collection.Add(property.EnumValidations()));
                            break;

                        case MemberTypes.Entity:
                            builder.Associations(collection => collection.Add(property.ToAssociation()));
                            break;

                        default:
                            Debug.Assert(false);
                            break;
                    }
                });

            return builder.ToModel();
        }

        public static ScriptResult Result(this Ext.data.Model model)
        {
            return new ScriptResult(model);
        }
    }
}