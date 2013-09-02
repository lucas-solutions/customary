using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Models.Ext
{
    using Custom.Metadata;

    public static class ModelViewModelExtensions
    {
        public static ModelViewModel ToModelViewModel(this EntityDescriptor entity)
        {
            if (entity == null)
                throw new ArgumentNullException();

            return null;
        }
    }
}