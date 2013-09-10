using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Presentation
{
    using Utilities;
    using System;
    using System.ComponentModel;

    [System.Serializable, System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter)), System.ComponentModel.Description("An object containing margins to apply to the region when in the expanded state.")]
    public class Margins : System.IEquatable<Margins>
    {
        private int bottom;
        private int left;
        private int right;
        private int top;

        [System.ComponentModel.Description("")]
        public Margins(int top, int right, int bottom, int left)
        {
            this.top = top;
            this.left = left;
            this.right = right;
            this.bottom = bottom;
        }

        [System.ComponentModel.Description("")]
        public virtual void Clear()
        {
            this.Top = -1;
            this.Right = -1;
            this.Bottom = -1;
            this.Left = -1;
        }

        [System.ComponentModel.Description("")]
        public virtual bool Equals(Margins margins)
        {
            return this.ToString().Equals(margins.ToString());
        }

        [System.ComponentModel.Description("")]
        public override bool Equals(object obj)
        {
            return (bool)((obj is Margins) && this.Equals((Margins)obj));
        }

        [System.ComponentModel.Description("")]
        public override int GetHashCode()
        {
            int num = System.Convert.ToInt32(this.Bottom);
            num = (int)((0x1d * num) + System.Convert.ToInt32(this.Left));
            num = (int)((0x1d * num) + System.Convert.ToInt32(this.Right));
            return (int)((0x1d * num) + System.Convert.ToInt32(this.Top));
        }

        [System.ComponentModel.Description("")]
        public override string ToString()
        {
            return "{0} {1} {2} {3}".FormatWith(((object[])new object[] { ((int)this.Top), ((int)this.Right), ((int)this.Bottom), ((int)this.Left) }));
        }

        [System.ComponentModel.NotifyParentProperty(true), System.ComponentModel.Description(""), System.ComponentModel.DefaultValue(-1)]
        public int Bottom
        {
            get
            {
                return this.bottom;
            }
            set
            {
                this.bottom = value;
            }
        }

        [System.ComponentModel.Description("Does this object currently represent it's default state."), System.ComponentModel.Browsable(false), System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public virtual bool IsDefault
        {
            get
            {
                return this.ToString().Equals("-1 -1 -1 -1");
            }
        }

        [System.ComponentModel.Description(""), System.ComponentModel.NotifyParentProperty(true), System.ComponentModel.DefaultValue(-1)]
        public int Left
        {
            get
            {
                return this.left;
            }
            set
            {
                this.left = value;
            }
        }

        [System.ComponentModel.NotifyParentProperty(true), System.ComponentModel.Description(""), System.ComponentModel.DefaultValue(-1)]
        public int Right
        {
            get
            {
                return this.right;
            }
            set
            {
                this.right = value;
            }
        }

        [System.ComponentModel.NotifyParentProperty(true), System.ComponentModel.Description(""), System.ComponentModel.DefaultValue(-1)]
        public int Top
        {
            get
            {
                return this.top;
            }
            set
            {
                this.top = value;
            }
        }
    }
}