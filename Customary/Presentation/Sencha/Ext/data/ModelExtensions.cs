using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.Ext.data
{
    using Custom.Metadata;
    using Custom.Results;

    public static class ModelExtensions
    {
        public static IEnumerable<Ext.data.Validations> EnumValidations(this PropertyDescriptor property)
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
                .Define(entity.Name)
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

            entity.Properties.ForEach(property =>
                {
                    var type = Global.Metadata.Describe(property.PropertyType);

                    if (type == null)
                    {
                    }

                    /*switch (type.MemberType)
                    {
                        case MemberTypes.Primitive:
                            builder.Fields(collection => collection.Add(property.ToField()));
                            builder.Validations(collection => collection.Add(property.EnumValidations()));
                            break;

                        case MemberTypes.Enum:
                            builder.Fields(collection => collection.Add(property.ToField()));
                            builder.Validations(collection => collection.Add(property.EnumValidations()));
                            break;

                        case MemberTypes.Quantity:
                            builder.Fields(collection => collection.Add(property.ToField()));
                            builder.Validations(collection => collection.Add(property.EnumValidations()));
                            break;

                        case MemberTypes.Entity:
                            builder.Associations(collection => collection.Add(property.ToAssociation()));
                            break;

                        default:
                            Debug.Assert(false);
                            break;
                    }*/
                });

            return builder.ToModel();
        }
    }
}