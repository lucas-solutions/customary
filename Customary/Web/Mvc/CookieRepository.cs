using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace Custom.Web.Mvc
{
    public class CookieRepository : DynamicObject
    {
        private readonly Dictionary<string, HttpCookie> _cookies = new Dictionary<string, HttpCookie>();
        private readonly HttpContext _context;
        private readonly TimeSpan _slidingExpiration;
        private readonly bool _cloned;
        private readonly bool _cached;
        private readonly bool _shared;
        private readonly bool _secure;

        public CookieRepository(HttpContext context, TimeSpan slidingExpiration, bool cloned = true, bool shared = false, bool cached = false, bool secure = false)
        {
            _context = context;
            _slidingExpiration = slidingExpiration;
            _cloned = cloned;
            _cached = cached;
            _shared = shared;
            _secure = !!shared && secure;
        }

        public HttpCookie this[string name]
        {
            get { return Get(name); }
            set { Set(name, value); }
        }

        public HttpCookie Get(string name)
        {
            HttpCookie cookie;
            if (!_cookies.TryGetValue(name, out cookie))
            {
                cookie = _context.Request.Cookies[name] ?? new HttpCookie(name);
                cookie.Expires = DateTime.Now + _slidingExpiration;
                cookie.Shareable = _cached;
                cookie.HttpOnly = _shared;
                cookie.Secure = _secure;
                _context.Response.Cookies.Add(cookie);
                _cookies.Add(name, cookie);
            }
            return cookie;
        }

        public T Get<T>(string name)
        {
            var cookie = Get(name);
            if (typeof(T).IsSubclassOf(typeof(HttpCookie)))
                return (T)(object)cookie;
            object result;
            return TryConvert(cookie.Value, typeof(T), out result) ? (T)result : default(T);
        }

        public void Set(string name, HttpCookie cookie)
        {
            if (cookie == null)
                _context.Response.Cookies.Remove(name);
            else
            {
                cookie.Name = name;
                cookie.Expires = DateTime.Now + _slidingExpiration;
                _context.Response.Cookies.Add(cookie);
            }
        }

        public void Set<T>(string name, T value)
        {
            if (typeof(T).IsSubclassOf(typeof(HttpCookie)))
                Set(name, value as HttpCookie);
            else
            {
                var cookie = Get(name);
                cookie.Value = value != null ? value.ToString() : null;
            }
        }

        private bool TryConvert(string value, Type type, out object result)
        {
            result = null;

            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Boolean:
                    {
                        bool b;
                        result = value != null && bool.TryParse(value, out b) ? b : default(bool);
                    }
                    break;

                case TypeCode.Byte:
                    {
                        byte b;
                        result = value != null && byte.TryParse(value, out b) ? b : default(byte);
                    }
                    break;

                case TypeCode.Char:
                    {
                        char c;
                        result = value != null && char.TryParse(value, out c) ? c : default(char);
                    }
                    break;

                case TypeCode.DateTime:
                    {
                        DateTime dt;
                        result = value != null && DateTime.TryParse(value, out dt) ? dt : default(DateTime);
                    }
                    break;

                case TypeCode.DBNull:
                    break;

                case TypeCode.Decimal:
                    {
                        decimal d;
                        result = value != null && decimal.TryParse(value, out d) ? d : default(decimal);
                    }
                    break;

                case TypeCode.Double:
                    {
                        double d;
                        result = value != null && double.TryParse(value, out d) ? d : default(double);
                    }
                    break;

                case TypeCode.Empty:
                    break;

                case TypeCode.Int16:
                    {
                        short s;
                        result = value != null && short.TryParse(value, out s) ? s : default(sbyte);
                    }
                    break;

                case TypeCode.Int32:
                    {
                        int i;
                        result = value != null && int.TryParse(value, out i) ? i : default(int);
                    }
                    break;

                case TypeCode.Int64:
                    {
                        long l;
                        result = value != null && long.TryParse(value, out l) ? l : default(long);
                    }
                    break;

                case TypeCode.Object:
                    {
                        result = value;
                    }
                    break;

                case TypeCode.UInt16:
                    {
                        ushort us;
                        result = value != null && ushort.TryParse(value, out us) ? us : default(ushort);
                    }
                    break;

                case TypeCode.UInt32:
                    {
                        uint ui;
                        result = value != null && uint.TryParse(value, out ui) ? ui : default(uint);
                    }
                    break;

                case TypeCode.UInt64:
                    {
                        ulong ul;
                        result = value != null && ulong.TryParse(value, out ul) ? ul : default(ulong);
                    }
                    break;
            }

            return true;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = null;
            var cookie = Get(binder.Name);
            if (binder.ReturnType.IsSubclassOf(typeof(HttpCookie)))
            {
                result = cookie;
                return true;
            }
            return TryConvert(cookie.Value, binder.ReturnType, out result);
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            Set(binder.Name, value as HttpCookie);
            return true;
        }
    }
}