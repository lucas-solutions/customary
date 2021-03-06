﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Custom.Data.Metadata
{
    using Custom.Data.Metadata;

    public class BaseDefinition
    {
        private Text _title;
        private Text _summary;

        public string Name
        {
            get;
            set;
        }

        public Text Title
        {
            get { return _title ?? (_title = new Text()); }
            set { _title = value; }
        }

        public Text Summary
        {
            get { return _summary ?? (_summary = new Text()); }
            set { _summary = value; }
        }
    }
}