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
                        ID = Guid.NewGuid(),
                        Name = "Entity",
                        Namespace = "Metadata",
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
                        Members = new List<MemberDescriptor>
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
                    }
                    #endregion - Entity -
                });
            }
        }

        private EntityRepository()
        {
        }
    }
}