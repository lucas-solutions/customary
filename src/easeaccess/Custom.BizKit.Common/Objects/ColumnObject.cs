using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Objects
{
    using Newtonsoft.Json.Linq;

    public class ColumnObject : MasterdataObject
    {
        public static implicit operator JObject(ColumnObject column)
        {
            if (column == null)
                return null;

            var json = new JObject();
            Set(json, "flex", column.Flex);
            Set(json, "fixed", column.Fixed);
            Set(json, "width", column.Width);
            return json;
        }

        public byte? Flex
        {
            get;
            set;
        }

        public bool? Fixed
        {
            get;
            set;
        }

        public int? Width
        {
            get;
            set;
        }
    }
}
