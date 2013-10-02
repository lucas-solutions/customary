using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Custom.Configuration
{
    public class CustomSesction : ConfigurationSection
    {
        [ConfigurationProperty("quoteOfTheDay", DefaultValue = "It is what it is.", IsRequired = false)]
        public string QuoteOfTheDay
        {
            get
            {
                return this["quoteOfTheDay"] as string;
            }
        }

        [ConfigurationProperty("yourAge", IsRequired = true)]
        public int YourAge
        {
            get
            {
                return (int)this["yourAge"];
            }
        }
    }
}