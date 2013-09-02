using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Models
{
    public class Service
    {
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// SQL Server, JSON, WCF
        /// </summary>
        public string Type
        {
            get;
            set;
        }
    }
}
