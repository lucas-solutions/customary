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

        Select = 1,

        Insert = 2,

        Update = 3,

        Delete = 4,

        Invoke = 5,

        Validate = 6,

        Read = Select,

        Create = Insert,

        Destroy = Delete,

        Call = Invoke,

        Children = 12
    }
}