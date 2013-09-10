
namespace Custom.Presentation.Sencha.Ext
{
    using Newtonsoft.Json;
    using System.Xml.Serialization;

    public abstract class ExtObject : IXObject
    {
        protected ExtObject()
        {
        }

        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden), System.ComponentModel.Browsable(false), System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never), XmlIgnore, JsonIgnore]
        public virtual ConfigOptionsCollection ConfigOptions
        {
            get
            {
                return new ConfigOptionsCollection();
            }
        }

        [System.ComponentModel.Browsable(false), System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden), System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never), XmlIgnore, JsonIgnore]
        public virtual ConfigOptionsExtraction ConfigOptionsExtraction
        {
            get
            {
                return ConfigOptionsExtraction.List;
            }
        }
    }
}