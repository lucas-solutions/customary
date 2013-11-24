using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Data
{
    using Custom.Data.Metadata;
    using global::Raven.Abstractions.Data;
    using global::Raven.Json.Linq;

    public class ValueDescriptor : TypeDescriptor<ValueDefinition>
    {
        public ValueDescriptor(Guid id, string name, NameDescriptor parent, JsonDocument jsonDocument)
            : base(id, name, parent, jsonDocument)
        {
        }

        public override TypeCategories Category
        {
            get { return TypeCategories.Value; }
        }

        internal protected override void Metadata(Stack<RavenJObject> stack, string[] requires, Dictionary<string, TypeDescriptor> types)
        {
            var valueJObject = this.DataAsJson;
            valueJObject["$type"] = "value";

            var nameJObject = stack.Peek();
            nameJObject.Remove("$dirty");
            nameJObject["$"] = valueJObject;
            
            var definition = Definition;

            //valueJObject.SetCurrentThreadCultureText("$title", definition.Title);
            //valueJObject.SetCurrentThreadCultureText("$summary", definition.Summary);

            //var validationsJArray = new RavenJArray();
            //valueJObject["$validations"] = validationsJArray;

            var validations = definition.Validations;

            if (validations != null)
            {
                foreach (var validation in validations)
                {
                    //var validationJObject = new RavenJObject();
                    
                    //validationJObject["$name"] = validation.Name;
                    //validationJObject["$type"] = validation.Name;

                    //if (validation.List != null)
                    //{
                    //    validationJObject["$list"] = validation.List;
                    //}

                    //if (validation.Matcher != null)
                    //{
                    //    validationJObject["$matcher"] = validation.Matcher;
                    //}

                    //if (validation.Max.HasValue)
                    //{
                    //    validationJObject["$max"] = validation.Max.Value;
                    //}

                    //if (validation.Min.HasValue)
                    //{
                    //    validationJObject["$min"] = validation.Min.Value;
                    //}

                    //validationJObject.SetCurrentThreadCultureText("$title", validation.Title);
                    //validationJObject.SetCurrentThreadCultureText("$summary", validation.Summary);
                    
                    //validationsJArray.Add(validationJObject);
                }
            }
        }

        public override RavenJObject ToRavenJObject(bool deep)
        {
            return base.ToRavenJObject(false);
        }
    }
}