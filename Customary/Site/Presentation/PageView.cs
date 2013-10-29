using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Site.Presentation
{
    public class PageView
    {
        public static implicit operator Byte(PageView view) { return view != null ? view.Value : (byte)0; }

        public static implicit operator PageView(Byte value) { return new PageView { Value = value }; }

        private byte _value;

        public PageFramework Framework
        {
            get { return (PageFramework)(0x07 & _value); }
            set { _value = (byte)((0x70 & _value) | (0x07 & (int)value)); }
        }

        public PageLayout Layout
        {
            get { return (PageLayout)(0x70 & _value); }
            set { _value = (byte)((0x70 & (int)value) | (0x07 & _value)); }
        }

        public Byte Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public override string ToString()
        {
            return string.Format("Layout: {0}, Framework: {1}", Layout, Framework);
        }
    }
}