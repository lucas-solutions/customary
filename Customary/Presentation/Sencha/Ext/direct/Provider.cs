﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.Ext.direct
{
    public abstract class Provider : Ext.Class
    {
        public static implicit operator Ext.util.Observable(Ext.direct.Provider model)
        {
            return model.Mixins.Get<Ext.util.Observable>();
        }
    }
}