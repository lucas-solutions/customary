using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Resources
{
    using Custom.Objects;
    using Raven.Imports.Newtonsoft.Json.Linq;
    using Raven.Json.Linq;

    public class Column : Metadata<ColumnObject>
    {
        private readonly Grid _grid;

        public Column(RavenJObject entity, Grid grid, string path)
            : base(entity)
        {
            _grid = grid;
        }

        public Grid Grid
        {
            get { return _grid; }
        }

        public Property Property
        {
            get;
            set;
        }
    }
}