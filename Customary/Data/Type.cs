using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Data
{
    public class Type : Node
    {
        public string Type
        {
            get { return Key.Split('/').Reverse().Skip(1).FirstOrDefault(); }
        }
    }
}