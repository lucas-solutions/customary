using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Objects
{
    public class LinkObject
    {
        private string _type;
        private string _multiplicity;

        public string Type
        {
            get { return _type ?? (_type = LinkTypes.Association); }
            set { _type = value; }
        }

        /// <summary>
        /// 0..1	No instances, or one instance (optional, may)
        /// 1	Exactly one instance
        /// 0..* or *	Zero or more instances
        /// 1..*	One or more instances (at least one)
        /// </summary>
        public string Multiplicity
        {
            get { return _multiplicity ?? (_multiplicity = "*"); }
            set { _multiplicity = value; }
        }

        public string Principal
        {
            get;
            set;
        }

        public string Dependant
        {
            get;
            set;
        }

        public string PrimaryKey
        {
            get;
            set;
        }

        public string ForeignKey
        {
            get;
            set;
        }
    }
}