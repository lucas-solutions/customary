using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Areas.Metadata.Models
{
    using Custom.Metadata;

    public class EntityRepository : List<EntityDescriptor>
    {
        static EntityRepository _current;

        public static EntityRepository Current
        {
            get
            {
                return _current ?? (_current = new EntityRepository
                {
                    #region - Entity -
                    new EntityDescriptor
                    {
                        Name = "Entity",
                        Title = new TextObject
                        {
                            { "en", "Entity" },
                            { "es", "Entidad" }
                        },
                        Summary = new TextObject
                        {
                            { "en", "Business Object" },
                            { "es", "Objecto de negocio" }
                        },
                        Properties = new List<PropertyDescriptor>
                        {
                            #region - ID -
                            new PropertyDescriptor
                            {
                                Name = "ID",
                                PropertyType = "Guid",
                                Title = new TextObject
                                {
                                    { "en", "Identity" },
                                    { "es", "Identidad" }
                                },
                                Summary = new TextObject
                                {
                                    { "en", "Identity property" },
                                    { "es", "Propiedad identidad" }
                                },
                                MemberType = MemberTypes.Property
                            },
                            #endregion - Entity -
                            #region - Name -
                            new PropertyDescriptor
                            {
                                Name = "Name",
                                PropertyType = "String",
                                Title = new TextObject
                                {
                                    { "en", "Name" },
                                    { "es", "Nombre" }
                                },
                                Summary = new TextObject
                                {
                                    { "en", "Name property" },
                                    { "es", "Propiedad nombre" }
                                },
                                MemberType = MemberTypes.Property
                            },
                            #endregion - Name -
                        },
                        MemberType = MemberTypes.Entity
                    },
                    #endregion - Entity -
                    #region - Property -
                    new EntityDescriptor
                    {
                        ID = Guid.NewGuid(),
                        Name = "Property",
                        Namespace = "Metadata",
                        Title = new TextObject
                        {
                            { "en", "Property" },
                            { "es", "Propiedad" }
                        },
                        Summary = new TextObject
                        {
                            { "en", "Business Object property" },
                            { "es", "Propiedad de Objecto de negocio" }
                        },
                        Properties = new List<PropertyDescriptor>
                        {
                            #region - ID -
                            new PropertyDescriptor
                            {
                                Name = "ID",
                                PropertyType = "Guid",
                                Title = new TextObject
                                {
                                    { "en", "Identity" },
                                    { "es", "Identidad" }
                                },
                                Summary = new TextObject
                                {
                                    { "en", "Identity property" },
                                    { "es", "Propiedad identidad" }
                                },
                                MemberType = MemberTypes.Property
                            },
                            #endregion - Property -
                            #region - Name -
                            new PropertyDescriptor
                            {
                                Name = "Name",
                                PropertyType = "String",
                                Title = new TextObject
                                {
                                    { "en", "Name" },
                                    { "es", "Nombre" }
                                },
                                Summary = new TextObject
                                {
                                    { "en", "Name property" },
                                    { "es", "Propiedad nombre" }
                                },
                                MemberType = MemberTypes.Property
                            },
                            #endregion - Name -
                        },
                        MemberType = MemberTypes.Property
                    },
                    #endregion - Property -
                    #region - Enum -
                    new EntityDescriptor
                    {
                        ID = Guid.NewGuid(),
                        Name = "Enum",
                        Namespace = "Metadata",
                        Title = new TextObject
                        {
                            { "en", "Enum" },
                            { "es", "Entidad" }
                        },
                        Summary = new TextObject
                        {
                            { "en", "Business Object" },
                            { "es", "Objecto de negocio" }
                        },
                        Properties = new List<PropertyDescriptor>
                        {
                            #region - ID -
                            new PropertyDescriptor
                            {
                                Name = "ID",
                                PropertyType = "Guid",
                                Title = new TextObject
                                {
                                    { "en", "Identity" },
                                    { "es", "Identidad" }
                                },
                                Summary = new TextObject
                                {
                                    { "en", "Identity property" },
                                    { "es", "Propiedad identidad" }
                                },
                                MemberType = MemberTypes.Property
                            },
                            #endregion - Enum -
                            #region - Name -
                            new PropertyDescriptor
                            {
                                Name = "Name",
                                PropertyType = "String",
                                Title = new TextObject
                                {
                                    { "en", "Name" },
                                    { "es", "Nombre" }
                                },
                                Summary = new TextObject
                                {
                                    { "en", "Name property" },
                                    { "es", "Propiedad nombre" }
                                },
                                MemberType = MemberTypes.Property
                            },
                            #endregion - Name -
                        },
                        MemberType = MemberTypes.Enum
                    },
                    #endregion - Enum -
                    #region - Member -
                    new EntityDescriptor
                    {
                        ID = Guid.NewGuid(),
                        Name = "Member",
                        Namespace = "Metadata",
                        Title = new TextObject
                        {
                            { "en", "Member" },
                            { "es", "Propiedad" }
                        },
                        Summary = new TextObject
                        {
                            { "en", "Business Object property" },
                            { "es", "Propiedad de Objecto de negocio" }
                        },
                        Properties = new List<PropertyDescriptor>
                        {
                            #region - ID -
                            new PropertyDescriptor
                            {
                                Name = "ID",
                                PropertyType = "Guid",
                                Title = new TextObject
                                {
                                    { "en", "Identity" },
                                    { "es", "Identidad" }
                                },
                                Summary = new TextObject
                                {
                                    { "en", "Identity property" },
                                    { "es", "Propiedad identidad" }
                                },
                                MemberType = MemberTypes.Member
                            },
                            #endregion - Member -
                            #region - Name -
                            new PropertyDescriptor
                            {
                                Name = "Name",
                                PropertyType = "String",
                                Title = new TextObject
                                {
                                    { "en", "Name" },
                                    { "es", "Nombre" }
                                },
                                Summary = new TextObject
                                {
                                    { "en", "Name property" },
                                    { "es", "Propiedad nombre" }
                                },
                                MemberType = MemberTypes.Member
                            },
                            #endregion - Name -
                        },
                        MemberType = MemberTypes.Member
                    }
                    #endregion - Member -
                });
            }
        }

        private EntityRepository()
        {
        }
    }
}