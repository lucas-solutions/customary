using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Extensions
{
    using Newtonsoft.Json;

    public static class JsonExtensions
    {
        public static string ToJson(this object value)
        {
           return JsonConvert.SerializeObject(value);
        }
    }
}