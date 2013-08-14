using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Controllers
{
    public class Cookie
    {
        public static implicit operator HttpCookie(Cookie cookie) { return cookie._httpCookie; }
        public static implicit operator Cookie(HttpCookie httpCookie) { return new Cookie(httpCookie); }

        private readonly HttpCookie _httpCookie;

        public Cookie(string name)
        {
            _httpCookie = new HttpCookie(name);
        }

        public Cookie(HttpCookie httpCookie)
        {
            _httpCookie = httpCookie;
        }

        public T Get<T>()
        {
            object result;
            return TryConvert(_httpCookie.Value, typeof(T), out result) ? (T)result : default(T);
        }

        public T Get<T>(string name)
        {
            object result;
            return TryConvert(_httpCookie.Values[name], typeof(T), out result) ? (T)result : default(T);
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

        public override string ToString()
        {
            return _httpCookie.Name;
        }
    }
}