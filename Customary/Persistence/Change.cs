using System;
using System.Net;

namespace Custom.Presistence
{
    public class Change
    {
        public string Who
        {
            get;
            set;
        }

        public DateTime When
        {
            get;
            set;
        }

        public IPAddress Where
        {
            get;
            set;
        }

        public string Why
        {
            get;
            set;
        }
    }
}