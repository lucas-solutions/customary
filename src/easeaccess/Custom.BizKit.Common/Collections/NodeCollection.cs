using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Xml.Serialization;

namespace Custom.Collections
{
    [Description("")]
    public class NodeCollection : BaseItemCollection<Node>, ICustomConfigSerialization
    {
        [Description("")]
        public NodeCollection()
            : this(false)
        {
        }

        [Description("")]
        public NodeCollection(bool single)
        {
            this.SingleItemMode = single;
        }

        [Description("")]
        public string ToJson()
        {
            StringBuilder builder = new StringBuilder(0x100);
            bool flag = false;
            builder.Append("[");
            foreach (Node node in this)
            {
                if (flag)
                {
                    builder.Append(",");
                }
                builder.Append(new ClientConfig().Serialize(node));
                flag = true;
            }
            builder.Append("]");
            return builder.ToString();
        }

        public string ToScript(Control owner)
        {
            return this.ToJson();
        }

        [EditorBrowsable(EditorBrowsableState.Never), Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), XmlIgnore, JsonIgnore]
        public override ConfigOptionsCollection ConfigOptions
        {
            get
            {
                ConfigOptionsCollection configOptions = base.ConfigOptions;
                configOptions.Add("primary", new ConfigOption("primary", new SerializationOptions(JsonMode.ObjectAllowEmpty), null, this.Primary));
                return configOptions;
            }
        }

        [Description(""), ConfigOption(JsonMode.ObjectAllowEmpty)]
        public Node Primary
        {
            get
            {
                if (this.Count > 0)
                {
                    return base[0];
                }
                return null;
            }
        }
    }
}
