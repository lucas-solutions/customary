using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Custom.Utils.OAuth
{
    /// <summary>
    /// 
    /// </summary>
    public class AccessTokenInfo
    {
        private Dictionary<String, String> _values = null;
        private string _token = "";
        private string _tokenSecret = "";
        /// <summary>
        /// 
        /// </summary>
        public string Token
        {
            get { return _token; }
            set { _token = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TokenSecret
        {
            get { return _tokenSecret; }
            set { _tokenSecret = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Dictionary<String, String> Values
        {
            get { return _values; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <param name="tokenSecret"></param>
        public AccessTokenInfo(string token, string tokenSecret)
        {
            this.Token = token;
            this.TokenSecret = tokenSecret;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="tokenKey"></param>
        /// <param name="tokenSecretKey"></param>
        /// <returns></returns>
        public static AccessTokenInfo Create(string value, string tokenKey, string tokenSecretKey)
        {
            AccessTokenInfo t = new AccessTokenInfo("", "");
            String[] ss = value.Split('&');
            String[] sss = null;
            Dictionary<String, String> d = new Dictionary<string, string>();
            for (int i = 0; i < ss.Length; i++)
            {
                if (ss[i].Contains("=") == false) { continue; }
                sss = ss[i].Split('=');
                if (sss.Length == 2)
                {
                    d[sss[0].ToLower()] = sss[1];
                }
            }
            t._values = d;
            if (d.ContainsKey(tokenKey) == true)
            {
                t.Token = d[tokenKey];
            }
            if (d.ContainsKey(tokenSecretKey) == true)
            {
                t.TokenSecret = d[tokenSecretKey];
            }
            return t;
        }
   }
}
