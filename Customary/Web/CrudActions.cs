using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Custom.Web
{
    [DefaultValue(CrudActions.Default)]
    public enum CrudActions
    {
        Default = 0,

        Create = 1,

        Read = 2,

        Update = 3,

        Delete = 4,

        Destroy = Delete
    }
}