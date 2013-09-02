using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Utils
{
    internal static class IpParser
    {
        public static byte[] Parse(string address)
        {
            if (string.IsNullOrEmpty(address))
                return null;

            var ip = new List<byte>(4);

            foreach (var token in address.Split('.'))
            {
                if (ip.Count >= 4)
                {
                    ip.Clear();
                    break;
                }

                byte part;
                if (!byte.TryParse(token, out part))
                {
                    ip.Clear();
                    break;
                }

                ip.Add(part);
            }

            return ip.Count > 0 ? ip.ToArray() : null;
        }
    }
}
