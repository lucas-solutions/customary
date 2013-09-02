using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Objects
{
    /// <summary>
    /// Model-Model Association
    /// </summary>
    public class AssociationObject
    {
        private string _multiplicity;

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