using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Metadata
{
    public class ServiceDescriptor : Descriptor
    {
        private List<RequestDescriptor> _requests;

        public List<RequestDescriptor> Requests
        {
            get { return _requests ?? (_requests = new List<RequestDescriptor>()); }
            set { _requests = value; }
        }
    }
}
