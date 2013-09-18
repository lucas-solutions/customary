using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Presentation.Sencha.Ext.data
{
    public class ValidationsCollection : ScriptArray<ValidationsCollection, Validations>
    {
        public ValidationsCollection Add(ValidationTypes type, string field, int? min, string[] list, string matcher)
        {
            Items.Add(new Validations { Type = type, Field = field, Min = min, List = list, Matcher = matcher });
            return this;
        }

        public ValidationsCollection Exclusion(string field, string[] list)
        {
            Items.Add(new Validations { Type = ValidationTypes.Exclusion, Field = field, List = list });
            return this;
        }

        public ValidationsCollection Format(string field, string matcher)
        {
            Items.Add(new Validations { Type = ValidationTypes.Format, Field = field, Matcher = matcher });
            return this;
        }

        public ValidationsCollection Inclusion(string field, string[] list)
        {
            Items.Add(new Validations { Type = ValidationTypes.Inclusion, Field = field, List = list });
            return this;
        }

        public ValidationsCollection Length(string field, int min)
        {
            Items.Add(new Validations { Type = ValidationTypes.Length, Field = field, Min = min });
            return this;
        }

        public ValidationsCollection Presence(string field)
        {
            Items.Add(new Validations { Type = ValidationTypes.Presence, Field = field });
            return this;
        }
    }
}