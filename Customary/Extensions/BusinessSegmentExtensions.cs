using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Custom.Documents
{
    public static class BusinessSegmentExtensions
    {
        public static BusinessSegment Store(this BusinessSegment segment)
        {
            var parent = segment.Parent;

            if (parent != null)
            {
                parent = parent.Store();
                var entity = parent.Segments.SingleOrDefault(o => o.Name == segment.Name);
                if (entity != null)
                {
                }
                else
                {
                }
                return segment;
            }
            else
            {
                var domain = segment as BusinessDomain;
                Debug.Assert(segment is BusinessDomain);
                domain = BusinessDomainExtensions.Store(domain);
                return domain;
            }
        }
    }
}