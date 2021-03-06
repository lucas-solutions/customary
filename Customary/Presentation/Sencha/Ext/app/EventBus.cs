﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.Ext.app
{
    public abstract class EventBus : Ext.Class
    {
        public static implicit operator Ext.util.Observable(Ext.app.EventBus model)
        {
            return model.Mixins.Get<Ext.util.Observable>();
        }
    }
}