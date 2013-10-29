using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Site.Presentation
{
    public class PageMatrix
    {
        public static implicit operator UInt64(PageMatrix matrix) { return matrix != null ? matrix.Value : 0; }

        public static implicit operator PageMatrix(UInt64 value) { return new PageMatrix { Value = value }; }

        private ulong _value;

        public UInt64 Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public PageView[] Views
        {
            get;
            set;
        }

        public bool Isset(PageFramework framework, PageLayout layout)
        {
            return false;
        }

        public bool Isset(PageView view)
        {
            return Isset(view.Framework, view.Layout);
        }

        public void Set(PageFramework framework, PageLayout layout)
        {
        }

        public void Set(PageView view)
        {
            Set(view.Framework, view.Layout);
        }

        public void Unset(PageFramework framework, PageLayout layout)
        {
        }

        public void Unset(PageView view)
        {
            Unset(view.Framework, view.Layout);
        }
    }
}