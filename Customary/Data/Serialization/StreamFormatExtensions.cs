using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Data.Serialization
{
    public static class StreamFormatExtensions
    {
        public static bool Any(this StreamFormat left, params StreamFormat[] right)
        {
            if (left == null)
            {
                return (right == null);
            }
            if (right == null)
            {
                return (left == null);
            }
            return right.Any(o => o.Equals(left));
        }

        public static bool Any(this StreamFormat[] left, params StreamFormat[] right)
        {
            if (left == null)
            {
                return (right == null);
            }
            if (right == null)
            {
                return (left == null);
            }

            return left.Any(x => right.Any(y => y.Equals(x)));
        }
    }
}