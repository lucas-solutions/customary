using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Utilities
{
    public abstract class Verify
    {
        protected Verify()
        {
        }

        public static void IsNotNull(object parameter, string parameterName)
        {
            if (parameter == null)
            {
                throw new ArgumentNullException(parameterName, parameterName);
            }
        }

        public static void IsString(object value, string paramterName)
        {
            if (!(value is string))
            {
                throw new ArgumentException(paramterName, paramterName);
            }
        }
    }
}