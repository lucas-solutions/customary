using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Custom.Models
{
    public class Text
    {
        public static implicit operator Text(String str)
        {
            return new Text
            {
                Culture = Thread.CurrentThread.CurrentCulture.Name,
                String = str
            };
        }

        public static implicit operator String(Text text)
        {
            return text != null ?  text.String : null;
        }

        public string Culture { get; set; }

        public string String { get; set; }

        public override string ToString()
        {
            return String;
        }
    }
}
