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
    [Meta]
    public class Node : BaseItem, IIcon, IClientConfig
    {
        private object attributesObject;
        private NodeCollection children;
        private ConfigItemCollection customAttributes;
        private TreeStoreListeners listeners;
        private Node parentNode;

        public Node()
        {
        }

        public Node(Config config)
        {
            base.Apply(config);
        }

        private void Nodes_AfterItemAdd(Node item)
        {
            item.ParentNode = this;
        }

        public static implicit operator Node(Config config)
        {
            return new Node(config);
        }

        public Builder ToBuilder()
        {
            return X.Builder.Node(this);
        }

        public override IControlBuilder ToNativeBuilder()
        {
            return (IControlBuilder)this.ToBuilder();
        }

        [Description("")]
        public string ToScript()
        {
            return this.ToScript(true);
        }

        [Description("")]
        public string ToScript(bool configOnly)
        {
            return new ClientConfig().Serialize(this);
        }

        [ConfigOption, NotifyParentProperty(true), Description("False to make this node undraggable if draggable = true (defaults to true)"), Meta, DefaultValue(true)]
        public virtual bool AllowDrag
        {
            get
            {
                return base.State.Get<bool>("AllowDrag", true);
            }
            set
            {
                base.State.Set("AllowDrag", (bool)value);
            }
        }

        [Description("False if this node cannot have child nodes dropped on it (defaults to true)"), Meta, DefaultValue(true), NotifyParentProperty(true), ConfigOption]
        public virtual bool AllowDrop
        {
            get
            {
                return base.State.Get<bool>("AllowDrop", true);
            }
            set
            {
                base.State.Set("AllowDrop", (bool)value);
            }
        }

        [DefaultValue((string)null), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), ConfigOption(JsonMode.Reflection), Meta, Browsable(false)]
        public virtual object AttributesObject
        {
            get
            {
                return this.attributesObject;
            }
            set
            {
                this.attributesObject = value;
            }
        }

        [Category("3. TreeNode"), Description("True to render a checked checkbox for this node, false to render an unchecked checkbox (defaults to undefined with no checkbox rendered)"), ConfigOption, Meta, DefaultValue((string)null), NotifyParentProperty(true)]
        public virtual bool? Checked
        {
            get
            {
                return base.State.Get<bool?>("Checked", null);
            }
            set
            {
                base.State.Set("Checked", value);
            }
        }

        [PersistenceMode(PersistenceMode.InnerProperty), Category("3. TreeNode"), NotifyParentProperty(true), Meta, Description("Array of child nodes."), ConfigOption(JsonMode.AlwaysArray)]
        public virtual NodeCollection Children
        {
            get
            {
                if (this.children == null)
                {
                    this.children = new NodeCollection(false);
                    this.children.AfterItemAdd += new BaseItemCollection<Node>.AfterItemAddHandler(this.Nodes_AfterItemAdd);
                }
                return this.children;
            }
        }

        [Meta, NotifyParentProperty(true), Description("A css class to be added to the node."), DefaultValue(""), ConfigOption, Category("3. TreeNode")]
        public virtual string Cls
        {
            get
            {
                return base.State.Get<string>("Cls", "");
            }
            set
            {
                base.State.Set("Cls", value);
            }
        }

        [XmlIgnore, EditorBrowsable(EditorBrowsableState.Never), JsonIgnore, DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Browsable(false)]
        public override ConfigOptionsCollection ConfigOptions
        {
            get
            {
                ConfigOptionsCollection configOptions = base.ConfigOptions;
                configOptions.Add("nodeID", new ConfigOption("nodeID", new SerializationOptions("id"), "", this.NodeID));
                configOptions.Add("leaf", new ConfigOption("leaf", null, false, (bool)this.Leaf));
                configOptions.Add("allowDrag", new ConfigOption("allowDrag", null, true, (bool)this.AllowDrag));
                configOptions.Add("allowDrop", new ConfigOption("allowDrop", null, true, (bool)this.AllowDrop));
                configOptions.Add("checked", new ConfigOption("checked", null, null, this.Checked));
                configOptions.Add("cls", new ConfigOption("cls", null, "", this.Cls));
                configOptions.Add("expandable", new ConfigOption("expandable", null, false, (bool)this.Expandable));
                configOptions.Add("expanded", new ConfigOption("expanded", null, false, (bool)this.Expanded));
                configOptions.Add("emptyChildrenProxy", new ConfigOption("emptyChildrenProxy", new SerializationOptions("children", JsonMode.Raw), "", this.EmptyChildrenProxy));
                configOptions.Add("href", new ConfigOption("href", new SerializationOptions(JsonMode.Url), "#", this.Href));
                configOptions.Add("hrefTarget", new ConfigOption("hrefTarget", null, "", this.HrefTarget));
                configOptions.Add("iconFile", new ConfigOption("iconFile", new SerializationOptions("icon"), "", this.IconFile));
                configOptions.Add("iconClsProxy", new ConfigOption("iconClsProxy", new SerializationOptions("iconCls"), "", this.IconClsProxy));
                configOptions.Add("qtip", new ConfigOption("qtip", null, "", this.Qtip));
                configOptions.Add("qtitle", new ConfigOption("qtitle", null, "", this.Qtitle));
                configOptions.Add("text", new ConfigOption("text", null, "", this.Text));
                configOptions.Add("children", new ConfigOption("children", new SerializationOptions(JsonMode.AlwaysArray), null, this.Children));
                configOptions.Add("dataPath", new ConfigOption("dataPath", null, "", this.DataPath));
                configOptions.Add("customAttributes", new ConfigOption("customAttributes", new SerializationOptions("-", typeof(CustomConfigJsonConverter)), null, this.CustomAttributes));
                configOptions.Add("attributesObject", new ConfigOption("attributesObject", new SerializationOptions(JsonMode.Reflection), null, this.AttributesObject));
                configOptions.Add("listeners", new ConfigOption("listeners", new SerializationOptions("listeners", JsonMode.Object), null, this.Listeners));
                return configOptions;
            }
        }

        [Meta, Description("Collection of custom node attributes"), ConfigOption("-", typeof(CustomConfigJsonConverter)), NotifyParentProperty(true), PersistenceMode(PersistenceMode.InnerProperty)]
        public virtual ConfigItemCollection CustomAttributes
        {
            get
            {
                if (this.customAttributes == null)
                {
                    this.customAttributes = new ConfigItemCollection();
                    this.customAttributes.CamelName = false;
                }
                return this.customAttributes;
            }
        }

        [ConfigOption, Meta, DefaultValue("")]
        public virtual string DataPath
        {
            get
            {
                return base.State.Get<string>("DataPath", "");
            }
            set
            {
                base.State.Set("DataPath", value);
            }
        }

        public virtual int Depth
        {
            get
            {
                int num = 0;
                for (Node node = this; node.ParentNode != null; node = node.ParentNode)
                {
                    num = (int)(num + 1);
                }
                return num;
            }
        }

        [Description("True to render empty children array"), Meta, Category("3. TreeNode"), DefaultValue(false), NotifyParentProperty(true)]
        public virtual bool EmptyChildren
        {
            get
            {
                return base.State.Get<bool>("EmptyChildren", false);
            }
            set
            {
                base.State.Set("EmptyChildren", (bool)value);
            }
        }

        [DefaultValue(""), ConfigOption("children", JsonMode.Raw)]
        protected virtual string EmptyChildrenProxy
        {
            get
            {
                if (!this.EmptyChildren)
                {
                    return "";
                }
                return "[]";
            }
        }

        [DefaultValue(false), Meta, ConfigOption, Category("3. TreeNode"), NotifyParentProperty(true), Description("Set to true to allow for expanding/collapsing of this node (the node will always show a plus/minus icon, even when empty). Defaults to: false")]
        public virtual bool Expandable
        {
            get
            {
                return base.State.Get<bool>("Expandable", false);
            }
            set
            {
                base.State.Set("Expandable", (bool)value);
            }
        }

        [Meta, Description("True to start the node expanded"), ConfigOption, Category("3. TreeNode"), DefaultValue(false), NotifyParentProperty(true)]
        public virtual bool Expanded
        {
            get
            {
                return base.State.Get<bool>("Expanded", false);
            }
            set
            {
                base.State.Set("Expanded", (bool)value);
            }
        }

        List<Ext.Net.Icon> IIcon.Icons
        {
            get
            {
                return new List<Ext.Net.Icon>(1) { this.Icon };
            }
        }

        [DefaultValue("#"), Description("URL of the link used for the node (defaults to #)"), ConfigOption(JsonMode.Url), Category("3. TreeNode"), Meta, NotifyParentProperty(true)]
        public virtual string Href
        {
            get
            {
                return base.State.Get<string>("Href", "#");
            }
            set
            {
                base.State.Set("Href", value);
            }
        }

        [ConfigOption, Description("Target for link. Only applicable when href also specified."), Meta, Category("3. TreeNode"), DefaultValue(""), NotifyParentProperty(true)]
        public virtual string HrefTarget
        {
            get
            {
                return base.State.Get<string>("HrefTarget", "");
            }
            set
            {
                base.State.Set("HrefTarget", value);
            }
        }

        [Meta, DefaultValue(0), NotifyParentProperty(true), Description("The icon to use for the Node. See also, IconCls to set an icon with a custom Css class."), Category("3. TreeNode")]
        public virtual Ext.Net.Icon Icon
        {
            get
            {
                return base.State.Get<Ext.Net.Icon>("Icon", Ext.Net.Icon.None);
            }
            set
            {
                base.State.Set("Icon", value);
            }
        }

        [DefaultValue(""), Description("A css class to be added to the nodes icon element for applying css background images"), Category("3. TreeNode"), Meta, NotifyParentProperty(true)]
        public virtual string IconCls
        {
            get
            {
                return base.State.Get<string>("IconCls", "");
            }
            set
            {
                base.State.Set("IconCls", value);
            }
        }

        [DefaultValue(""), ConfigOption("iconCls")]
        protected virtual string IconClsProxy
        {
            get
            {
                if (this.Icon != Ext.Net.Icon.None)
                {
                    return ResourceManager.GetIconRequester(this.Icon);
                }
                return this.IconCls;
            }
        }

        [Description("The path to an icon for the node. The preferred way to do this is to use the cls or iconCls attributes and add the icon via a CSS background image."), Meta, ConfigOption("icon"), Category("3. TreeNode"), DefaultValue(""), NotifyParentProperty(true)]
        public virtual string IconFile
        {
            get
            {
                return base.State.Get<string>("IconFile", "");
            }
            set
            {
                base.State.Set("IconFile", value);
            }
        }

        [Meta, ConfigOption, DefaultValue(false), NotifyParentProperty(true), Description("Set to true to indicate that this child can have no children. The expand icon/arrow will then not be rendered for this node. Defaults to: false")]
        public virtual bool Leaf
        {
            get
            {
                return base.State.Get<bool>("Leaf", false);
            }
            set
            {
                base.State.Set("Leaf", (bool)value);
            }
        }

        [NotifyParentProperty(true), ConfigOption("listeners", JsonMode.Object), PersistenceMode(PersistenceMode.InnerProperty), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), Description("Client-side JavaScript Event Handlers"), Category("2. Observable"), Meta]
        public TreeStoreListeners Listeners
        {
            get
            {
                if (this.listeners == null)
                {
                    this.listeners = new TreeStoreListeners();
                }
                return this.listeners;
            }
        }

        [NotifyParentProperty(true), Description("The id for this node. If one is not specified, one is generated."), ConfigOption("id"), DefaultValue(""), Meta]
        public virtual string NodeID
        {
            get
            {
                return base.State.Get<string>("NodeID", "");
            }
            set
            {
                base.State.Set("NodeID", value);
            }
        }

        [Description("")]
        public Node ParentNode
        {
            get
            {
                return this.parentNode;
            }
            protected internal set
            {
                this.parentNode = value;
            }
        }

        [Description("Tooltip text to show on this node."), Meta, ConfigOption, Category("3. TreeNode"), DefaultValue(""), NotifyParentProperty(true)]
        public virtual string Qtip
        {
            get
            {
                return base.State.Get<string>("Qtip", "");
            }
            set
            {
                base.State.Set("Qtip", value);
            }
        }

        [Description("Tooltip title."), Category("3. TreeNode"), NotifyParentProperty(true), Meta, DefaultValue(""), ConfigOption]
        public virtual string Qtitle
        {
            get
            {
                return base.State.Get<string>("Qtitle", "");
            }
            set
            {
                base.State.Set("Qtitle", value);
            }
        }

        [Category("3. TreeNode"), DefaultValue(""), NotifyParentProperty(true), Description("The text for to show on node label."), Meta, ConfigOption]
        public virtual string Text
        {
            get
            {
                return base.State.Get<string>("Text", "");
            }
            set
            {
                base.State.Set("Text", value);
            }
        }

        public class Builder : Node.Builder<Node, Node.Builder>
        {
            public Builder()
                : base(new Node())
            {
            }

            public Builder(Node component)
                : base(component)
            {
            }

            public Builder(Node.Config config)
                : base(new Node(config))
            {
            }

            public static implicit operator Node.Builder(Node component)
            {
                return component.ToBuilder();
            }
        }

        public abstract class Builder<TNode, TBuilder> : BaseItem.Builder<TNode, TBuilder>
            where TNode : Node
            where TBuilder : Node.Builder<TNode, TBuilder>
        {
            public Builder(TNode component)
                : base(component)
            {
            }

            public virtual TBuilder AllowDrag(bool allowDrag)
            {
                this.ToComponent().AllowDrag = allowDrag;
                return (this as TBuilder);
            }

            public virtual TBuilder AllowDrop(bool allowDrop)
            {
                this.ToComponent().AllowDrop = allowDrop;
                return (this as TBuilder);
            }

            public virtual TBuilder AttributesObject(object attributesObject)
            {
                this.ToComponent().AttributesObject = attributesObject;
                return (this as TBuilder);
            }

            public virtual TBuilder Checked(bool? _checked)
            {
                this.ToComponent().Checked = _checked;
                return (this as TBuilder);
            }

            public virtual TBuilder Children(params Node[] nodes)
            {
                this.ToComponent().Children.AddRange(nodes);
                return (this as TBuilder);
            }

            public virtual TBuilder Children(Action<NodeCollection> action)
            {
                action(this.ToComponent().Children);
                return (this as TBuilder);
            }

            public virtual TBuilder Children(IEnumerable<Node> nodes)
            {
                this.ToComponent().Children.AddRange(nodes);
                return (this as TBuilder);
            }

            public virtual TBuilder Cls(string cls)
            {
                this.ToComponent().Cls = cls;
                return (this as TBuilder);
            }

            public virtual TBuilder CustomAttributes(object attributes)
            {
                this.ToComponent().CustomAttributes.Add(attributes);
                return (this as TBuilder);
            }

            public virtual TBuilder CustomAttributes(Action<ConfigItemCollection> action)
            {
                action(this.ToComponent().CustomAttributes);
                return (this as TBuilder);
            }

            public virtual TBuilder DataPath(string dataPath)
            {
                this.ToComponent().DataPath = dataPath;
                return (this as TBuilder);
            }

            public virtual TBuilder EmptyChildren(bool emptyChildren)
            {
                this.ToComponent().EmptyChildren = emptyChildren;
                return (this as TBuilder);
            }

            public virtual TBuilder Expandable(bool expandable)
            {
                this.ToComponent().Expandable = expandable;
                return (this as TBuilder);
            }

            public virtual TBuilder Expanded(bool expanded)
            {
                this.ToComponent().Expanded = expanded;
                return (this as TBuilder);
            }

            public virtual TBuilder Href(string href)
            {
                this.ToComponent().Href = href;
                return (this as TBuilder);
            }

            public virtual TBuilder HrefTarget(string hrefTarget)
            {
                this.ToComponent().HrefTarget = hrefTarget;
                return (this as TBuilder);
            }

            public virtual TBuilder Icon(Ext.Net.Icon icon)
            {
                this.ToComponent().Icon = icon;
                return (this as TBuilder);
            }

            public virtual TBuilder IconCls(string iconCls)
            {
                this.ToComponent().IconCls = iconCls;
                return (this as TBuilder);
            }

            public virtual TBuilder IconFile(string iconFile)
            {
                this.ToComponent().IconFile = iconFile;
                return (this as TBuilder);
            }

            public virtual TBuilder Leaf(bool leaf)
            {
                this.ToComponent().Leaf = leaf;
                return (this as TBuilder);
            }

            public virtual TBuilder Listeners(Action<TreeStoreListeners> action)
            {
                action(this.ToComponent().Listeners);
                return (this as TBuilder);
            }

            public virtual TBuilder NodeID(string nodeID)
            {
                this.ToComponent().NodeID = nodeID;
                return (this as TBuilder);
            }

            public virtual TBuilder Qtip(string qtip)
            {
                this.ToComponent().Qtip = qtip;
                return (this as TBuilder);
            }

            public virtual TBuilder Qtitle(string qtitle)
            {
                this.ToComponent().Qtitle = qtitle;
                return (this as TBuilder);
            }

            public virtual TBuilder Text(string text)
            {
                this.ToComponent().Text = text;
                return (this as TBuilder);
            }
        }

        public class Config : BaseItem.Config
        {
            private bool? _checked = null;
            private bool allowDrag = true;
            private bool allowDrop = true;
            private object attributesObject;
            private NodeCollection children;
            private string cls = "";
            private ConfigItemCollection customAttributes;
            private string dataPath = "";
            private bool emptyChildren;
            private bool expandable;
            private bool expanded;
            private string href = "#";
            private string hrefTarget = "";
            private Ext.Net.Icon icon;
            private string iconCls = "";
            private string iconFile = "";
            private bool leaf;
            private TreeStoreListeners listeners;
            private string nodeID = "";
            private string qtip = "";
            private string qtitle = "";
            private string text = "";

            public static implicit operator Node.Builder(Node.Config config)
            {
                return new Node.Builder(config);
            }

            [DefaultValue(true)]
            public virtual bool AllowDrag
            {
                get
                {
                    return this.allowDrag;
                }
                set
                {
                    this.allowDrag = value;
                }
            }

            [DefaultValue(true)]
            public virtual bool AllowDrop
            {
                get
                {
                    return this.allowDrop;
                }
                set
                {
                    this.allowDrop = value;
                }
            }

            [DefaultValue((string)null)]
            public virtual object AttributesObject
            {
                get
                {
                    return this.attributesObject;
                }
                set
                {
                    this.attributesObject = value;
                }
            }

            [DefaultValue((string)null)]
            public virtual bool? Checked
            {
                get
                {
                    return this._checked;
                }
                set
                {
                    this._checked = value;
                }
            }

            public NodeCollection Children
            {
                get
                {
                    if (this.children == null)
                    {
                        this.children = new NodeCollection();
                    }
                    return this.children;
                }
            }

            [DefaultValue("")]
            public virtual string Cls
            {
                get
                {
                    return this.cls;
                }
                set
                {
                    this.cls = value;
                }
            }

            public ConfigItemCollection CustomAttributes
            {
                get
                {
                    if (this.customAttributes == null)
                    {
                        this.customAttributes = new ConfigItemCollection();
                    }
                    return this.customAttributes;
                }
            }

            [DefaultValue("")]
            public virtual string DataPath
            {
                get
                {
                    return this.dataPath;
                }
                set
                {
                    this.dataPath = value;
                }
            }

            [DefaultValue(false)]
            public virtual bool EmptyChildren
            {
                get
                {
                    return this.emptyChildren;
                }
                set
                {
                    this.emptyChildren = value;
                }
            }

            [DefaultValue(false)]
            public virtual bool Expandable
            {
                get
                {
                    return this.expandable;
                }
                set
                {
                    this.expandable = value;
                }
            }

            [DefaultValue(false)]
            public virtual bool Expanded
            {
                get
                {
                    return this.expanded;
                }
                set
                {
                    this.expanded = value;
                }
            }

            [DefaultValue("#")]
            public virtual string Href
            {
                get
                {
                    return this.href;
                }
                set
                {
                    this.href = value;
                }
            }

            [DefaultValue("")]
            public virtual string HrefTarget
            {
                get
                {
                    return this.hrefTarget;
                }
                set
                {
                    this.hrefTarget = value;
                }
            }

            [DefaultValue(0)]
            public virtual Ext.Net.Icon Icon
            {
                get
                {
                    return this.icon;
                }
                set
                {
                    this.icon = value;
                }
            }

            [DefaultValue("")]
            public virtual string IconCls
            {
                get
                {
                    return this.iconCls;
                }
                set
                {
                    this.iconCls = value;
                }
            }

            [DefaultValue("")]
            public virtual string IconFile
            {
                get
                {
                    return this.iconFile;
                }
                set
                {
                    this.iconFile = value;
                }
            }

            [DefaultValue(false)]
            public virtual bool Leaf
            {
                get
                {
                    return this.leaf;
                }
                set
                {
                    this.leaf = value;
                }
            }

            public TreeStoreListeners Listeners
            {
                get
                {
                    if (this.listeners == null)
                    {
                        this.listeners = new TreeStoreListeners();
                    }
                    return this.listeners;
                }
            }

            [DefaultValue("")]
            public virtual string NodeID
            {
                get
                {
                    return this.nodeID;
                }
                set
                {
                    this.nodeID = value;
                }
            }

            [DefaultValue("")]
            public virtual string Qtip
            {
                get
                {
                    return this.qtip;
                }
                set
                {
                    this.qtip = value;
                }
            }

            [DefaultValue("")]
            public virtual string Qtitle
            {
                get
                {
                    return this.qtitle;
                }
                set
                {
                    this.qtitle = value;
                }
            }

            [DefaultValue("")]
            public virtual string Text
            {
                get
                {
                    return this.text;
                }
                set
                {
                    this.text = value;
                }
            }
        }
    }
}
