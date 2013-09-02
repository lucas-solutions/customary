using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Objects
{
    public class OperationObject : ComponentObject
    {
        public string Assembly
        {
            get;
            set;
        }

        public string Namespace
        {
            get;
            set;
        }

        public string Class
        {
            get;
            set;
        }

        public string Method
        {
            get;
            set;
        }

        /// <summary>
        /// input type name, it sould be a primiteve or a model
        /// </summary>
        public string InputType
        {
            get;
            set;
        }

        public string ReturnType
        {
            get;
            set;
        }
    }
}