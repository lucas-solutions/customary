using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Extensions
{
    using Newtonsoft.Json;
    using System.IO;

    public static class WebRequestExtensions
    {
        public static T Execute<T>(this WebRequest webRequest)
        {
            WebResponse webResponse;
            return Execute<T>(webRequest, out webResponse);
        }

        public static T Execute<T>(this WebRequest webRequest, out WebResponse webResponse)
        {
            T result;

            try
            {
                webResponse = webRequest.GetResponse();
                var response = webResponse.GetResponseStream();

                var jsonSerializer = new JsonSerializer();
                using (var textReader = new StreamReader(response))
                {
                    var jsonReader = new JsonTextReader(textReader);
                    result = jsonSerializer.Deserialize<T>(jsonReader);
                }
            }
            catch (WebException e)
            {
                throw e;
            }

            return result;
        }
    }
}
