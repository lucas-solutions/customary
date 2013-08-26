using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Reflection
{
    public enum PropertyRoles
    {
        Value = 0, // default
        Required = 1, // RequiredValue
        Reference = 2,
        Collection = 4,
        RequiredReference = Required | Reference,
        RequiredCollection = Required | Collection,
        Text = 6,
        Identity = 7,
    }
}