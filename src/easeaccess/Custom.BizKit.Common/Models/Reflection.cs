using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Models
{
    using Custom.Models;
    using Raven.Abstractions.Data;

    public abstract class Reflection
    {
        public abstract App App { get; }

        public abstract Area Area { get; }

        public abstract Column Column { get; }

        public abstract Field Field { get; }

        public abstract File File { get; }

        public abstract Model Form { get; }

        public abstract Grid Grid { get; }

        public abstract Item Item { get; }

        public abstract List List { get; }

        public abstract Note Note { get; }
    }
}
