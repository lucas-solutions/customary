using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Models
{
    public class ProcecssResult
    {
        private List<Annotation> _annotations;

        public List<Annotation> Annotations
        {
            get { return _annotations ?? (_annotations = new List<Annotation>()); }
        }

        public bool Success
        {
            get { return true; }
        }
    }
}