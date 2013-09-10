using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.Ext
{
    public class BaseItem
    {
        private ConfigOptionsCollection _configOptions;
        private ItemState _state;

        public BaseItem()
        {   
        }

        public ConfigOptionsCollection ConfigOptions
        {
            get { return _configOptions ?? (_configOptions = new ConfigOptionsCollection(); }
        }

        public ItemState State
        {
            get { return _state ?? (_state = new ItemState(this)); }
        }
    }
}