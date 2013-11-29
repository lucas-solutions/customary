using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Presentation
{
    public struct CssRect
    {
        public static implicit operator CssRect(int value)
        {
            return new CssRect { _all = value };
        }

        /// <summary>
        /// For example: "10 5 3 10"
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static implicit operator CssRect(string value)
        {
            var arr = value.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            int a, b, c, d;
            switch (arr.Length)
            {
                case 1:
                    if (int.TryParse(arr[0], out a))
                        return new CssRect { _all = a };
                    break;

                case 2:
                    if (int.TryParse(arr[0], out a) && int.TryParse(arr[1], out b))
                        return new CssRect { _vertical = a, _horizontal = b };
                    break;

                case 4:
                    if (int.TryParse(arr[0], out a) && int.TryParse(arr[1], out b) && int.TryParse(arr[2], out c) && int.TryParse(arr[3], out d))
                        return new CssRect { _top = a, _right = b, _bottom =  c, _left = d};
                    break;
            }
            return null;
        }

        private int? _all;
        private int? _bottom;
        private int? _horizontal;
        private int? _left;
        private int? _right;
        private int? _top;
        private int? _vertical;

        public int Bottom
        {
            get { return (_bottom ?? _all ?? (int?)0).Value; }
            set { _bottom = value; }
        }

        public int Left
        {
            get { return (_left ?? _all ?? (int?)0).Value; }
            set { _left = value; }
        }

        public int Right
        {
            get { return (_right ?? _all ?? (int?)0).Value; }
            set { _right = value; }
        }

        public int Top
        {
            get { return (_top ?? _all ?? (int?)0).Value; }
            set { _top = value; }
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3}", _top, _right, _bottom, _left);
        }
    }
}