﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Models
{
    public class FormViewModel
    {
        public ICollection<Area> Areas { get; set; }

        public Grid Grid { get; set; }

        public Form Form { get; set; }
    }
}