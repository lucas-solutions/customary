﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Custom.Presentation
{
    public interface IScriptSerializer
    {
        string[] Render();
        void Write(TextWriter writer);
    }
}