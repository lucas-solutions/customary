using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.Ext
{
    using System.ComponentModel;
    using System.Reflection;

    [System.ComponentModel.Description(""), System.ComponentModel.ToolboxItem(false)/*, System.ComponentModel.TypeConverter(typeof(ListenersConverter))*/]
    public abstract class ComponentListeners : BaseItem
    {
        private System.Collections.Generic.List<ListenerTriplet> listeners;
        private static readonly Dictionary<string, System.Collections.Generic.List<ListenerPropertyInfo>> propertiesCache = new Dictionary<string, System.Collections.Generic.List<ListenerPropertyInfo>>();
        private static readonly object syncObj = new object();

        protected ComponentListeners()
        {
        }

        [System.ComponentModel.Description("")]
        public virtual void ClearListeners()
        {
            foreach (ListenerTriplet triplet in this.Listeners)
            {
                triplet.Listener.Clear();
            }
        }

        private System.Collections.Generic.List<ListenerPropertyInfo> ListenerProperties
        {
            get
            {
                string str = base.GetType().get_FullName();
                if (propertiesCache.ContainsKey(str))
                {
                    return propertiesCache[str];
                }
                lock (syncObj)
                {
                    if (propertiesCache.ContainsKey(str))
                    {
                        return propertiesCache[str];
                    }
                    System.Collections.Generic.List<ListenerPropertyInfo> list = new System.Collections.Generic.List<ListenerPropertyInfo>();
                    System.Reflection.PropertyInfo[] properties = base.GetType().GetProperties();
                    for (int i = 0; i < properties.Length; i = (int)(i + 1))
                    {
                        System.Reflection.PropertyInfo property = properties[i];
                        if (property.PropertyType == typeof(ComponentListener))
                        {
                            ConfigOptionAttribute clientConfigAttribute = ClientConfig.GetClientConfigAttribute(property);
                            list.Add(new ListenerPropertyInfo(property, clientConfigAttribute));
                        }
                    }
                    propertiesCache.Add(str, list);
                    return list;
                }
            }
        }

        private System.Collections.Generic.List<ListenerTriplet> Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new System.Collections.Generic.List<ListenerTriplet>();
                    foreach (ListenerPropertyInfo info in this.ListenerProperties)
                    {
                        ComponentListener listener = info.PropertyInfo.GetValue(this, (object[])null) as ComponentListener;
                        if (listener != null)
                        {
                            this.listeners.Add(new ListenerTriplet(info.PropertyInfo.get_Name(), listener, info.Attribute));
                        }
                    }
                }
                return this.listeners;
            }
        }
    }
}