using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Models.Ext
{
    public class AssociationViewModel
    {
        public string HasMany
        {
            get;
            set;
        }

        public string BelongsTo
        {
            get;
            set;
        }
    }
}