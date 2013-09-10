using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Presentation
{
    public class JObject<TModel>
        where TModel : class
    {
        public static implicit operator JObject<TModel>(TModel model)
        {
            return new JObject<TModel> { Model = model };
        }

        public static implicit operator JObject<TModel>(string name)
        {
            return new JObject<TModel> { Name = name };
        }

        public static implicit operator TModel(JObject<TModel> o)
        {
            return o != null ? o.Model : null;
        }

        public static implicit operator string(JObject<TModel> o)
        {
            return o != null ? (!string.IsNullOrEmpty(o.Name) ? o.Name : (o.Model != null ? o.Model.ToString() : null)) : null;
        }

        public TModel Model
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }
    }
}