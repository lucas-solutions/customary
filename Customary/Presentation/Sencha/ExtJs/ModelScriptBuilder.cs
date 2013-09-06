using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.ExtJs
{
    using Custom.Metadata;

    public class ModelScriptBuilder : ScriptBuilder
    {
        private string _name;
        private string _extend;
        private ProxyScriptBuilder _proxy;
        private List<FieldScriptBuilder> _fields;
        private List<AssociationScriptBuilder> _associations;
        private List<ValidationScriptBuilder> _validations;

        public ModelScriptBuilder()
        {
        }

        public ModelScriptBuilder(EntityDescriptor entity)
        {
            _fields = new List<FieldScriptBuilder>();
            _associations = new List<AssociationScriptBuilder>();
            _validations = new List<ValidationScriptBuilder>();
            _proxy = new ProxyScriptBuilder();

            entity.Members.ForEach(member =>
                {
                    // Only properties
                    if (member.MemberType != MemberTypes.Property)
                        return;

                    var property = member as PropertyDescriptor;

                    Debug.Assert(property != null);

                    var type = Global.Metadata.Describe(property.PropertyType);

                    if (type == null)
                    {
                    }

                    switch (type.MemberType)
                    {
                        case MemberTypes.Primitive:
                            _fields.Add(new FieldScriptBuilder(property));
                            _validations.Add(new ValidationScriptBuilder(property.Name, type as PrimitiveDescriptor));
                            break;

                        case MemberTypes.Enum:
                            _fields.Add(new FieldScriptBuilder(property));
                            _validations.Add(new ValidationScriptBuilder(property.Name, type as EnumDescriptor));
                            break;

                        case MemberTypes.Unit:
                            _fields.Add(new FieldScriptBuilder(property));
                            _validations.Add(new ValidationScriptBuilder(property.Name, type as UnitDescriptor));
                            break;

                        case MemberTypes.Entity:
                            _associations.Add(new AssociationScriptBuilder(property));
                            break;

                        default:
                            Debug.Assert(false);
                            break;
                    }
                });
        }

        public ModelScriptBuilder Extend(string value)
        {
            _extend = value;
            return this;
        }

        public ModelScriptBuilder Name(string value)
        {
            _name = value;
            return this;
        }

        public ModelScriptBuilder Proxy(ProxyScriptBuilder value)
        {
            _proxy = value;
            return this;
        }

        public ModelScriptBuilder Proxy(Action<ProxyScriptBuilder> action)
        {
            action(_proxy ?? (_proxy = new ProxyScriptBuilder()));
            return this;
        }

        private void Proxy(TextWriter writer)
        {
            writer.Write("proxy: ");
            if (_proxy != null)
            {
                _proxy.Write(writer);
            }
            else
            {
                writer.Write("null");
            }
        }

        public ModelScriptBuilder Fields(Action<List<FieldScriptBuilder>> action)
        {
            action(_fields ?? (_fields = new List<FieldScriptBuilder>()));
            return this;
        }

        public ModelScriptBuilder Associations(Action<List<AssociationScriptBuilder>> action)
        {
            action(_associations ?? (_associations = new List<AssociationScriptBuilder>()));
            return this;
        }
        
        public ModelScriptBuilder Validations(Action<List<ValidationScriptBuilder>> action)
        {
            action(_validations ?? (_validations = new List<ValidationScriptBuilder>()));
            return this;
        }

        public override void Write(TextWriter writer)
        {
            writer.Write("Ext.regModel('" + _name + "', {");
            writer.WriteLine();
            Write(writer, _fields ?? new List<FieldScriptBuilder>());
            if (_associations != null && _associations.Count > 0)
            {
                writer.Write(',');
                writer.WriteLine();
                Write(writer, _associations);
            }
            if (_validations != null && _validations.Count > 0)
            {
                writer.Write(',');
                writer.WriteLine();
                Write(writer, _validations);
            }
            if (_proxy != null)
            {
                writer.Write(',');
                writer.WriteLine();
                Proxy(writer);
            }
            writer.WriteLine();
            writer.Write("});");
            writer.WriteLine();
        }

        private static void Write(TextWriter writer, IEnumerable<FieldScriptBuilder> list)
        {
            var enu = list.GetEnumerator();
            var any = enu.MoveNext();

            writer.Write("fields: [");
            writer.WriteLine();

            while (any)
            {
                enu.Current.Write(writer);

                if ((any = enu.MoveNext()))
                {
                    writer.Write(',');
                }

                writer.WriteLine();
            }

            writer.Write("]");
        }

        private static void Write(TextWriter writer, IEnumerable<AssociationScriptBuilder> list)
        {
            var enu = list.GetEnumerator();
            var any = enu.MoveNext();

            writer.Write("associations: [");
            writer.WriteLine();

            while (any)
            {
                enu.Current.Write(writer);

                if ((any = enu.MoveNext()))
                {
                    writer.Write(',');
                }

                writer.WriteLine();
            }

            writer.Write("]");

        }

        private static void Write(TextWriter writer, IEnumerable<ValidationScriptBuilder> list)
        {
            var enu = list.GetEnumerator();
            var any = enu.MoveNext();

            writer.Write("validations: [");
            writer.WriteLine();

            while (any)
            {
                enu.Current.Write(writer);

                if ((any = enu.MoveNext()))
                {
                    writer.Write(',');
                }

                writer.WriteLine();
            }

            writer.Write("]");
        }
    }
}