﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.Ext.data.reader
{
    public class Xml : Reader
    {
        protected override IScriptSerializer CreateSerializer()
        {
            return null;
        }
    }
}