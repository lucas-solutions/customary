using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.Extensions
{
    using Custom.Models;
    using Newtonsoft.Json;
    using Raven.Imports.Newtonsoft.Json.Linq;
    using Raven.Json.Linq;

    public static class RavenJObjectExtensions
    {
        private static string[] _readOnly = new []
        {
            "CreatedBy",
            "CreatedOn",
            "ModifiedBy",
            "ModifiedOn"
        };

        private static RavenJToken Update(RavenJTokenCallbackModel model)
        {
            switch (model.Token.Type)
            {
                case JTokenType.Object:
                    var obj = model.Token as RavenJObject;
                    RavenJToken id, pos;
                    if (obj.TryGetValue("id", out id) && id.Type.Equals(JTokenType.String))
                    {
                        model.Id = id.ToString();
                        obj.Remove("id");
                    }
                    if (obj.TryGetValue("pos", out pos) && pos.Type.Equals(JTokenType.Integer))
                    {
                        model.Position = (int)Convert.ChangeType(pos.ToString(), typeof(int));
                        obj.Remove("id");
                    }
                    foreach (var name in _readOnly)
                    {
                        if (obj.TryGetValue(name, out pos))
                            obj.Remove(name);
                    }
                    break;
            }
            return model.Token;
        }

        public static bool Each(this RavenJObject source, Func<RavenJTokenCallbackModel, bool> callback)
        {
            RavenJTokenCallbackModel model;

            var data = source["data"];

            if (data != null)
            {
                switch (data.Type)
                {
                    case JTokenType.Array:
                        var index = 0;
                        var array = data as RavenJArray;
                        foreach (var token in array)
                        {
                            model = new RavenJTokenCallbackModel { Token = token, Index = index };
                            Update(model);
                            if (!callback(model))
                                break;
                            index++;
                        }
                        break;

                    default:
                        model = new RavenJTokenCallbackModel { Token = data, Index = 0 };
                        Update(model);
                        callback(model);
                        break;
                }
            }
            else
            {
                model = new RavenJTokenCallbackModel { Token = source, Index = 0 };
                Update(model);
                callback(model);
            }

            return true;
        }

        public static bool Each<T>(this RavenJObject source, Func<RavenJTokenCallbackModel<T>, bool> callback)
        {
            RavenJTokenCallbackModel<T> model;

            var data = source["data"];

            if (data != null)
            {
                switch (data.Type)
                {
                    case JTokenType.Array:
                        var index = 0;
                        var array = data as RavenJArray;
                        foreach (var token in array)
                        {
                            model = new RavenJTokenCallbackModel<T> { Token = token, Index = index };
                            model.Value = JsonConvert.DeserializeObject<T>(Update(model).ToString());
                            if (!callback(model))
                                break;
                            index++;
                        }
                        break;

                    default:
                        model = new RavenJTokenCallbackModel<T> { Token = data, Index = 0 };
                        model.Value = JsonConvert.DeserializeObject<T>(Update(model).ToString());
                        callback(model);
                        break;
                }
            }
            else
            {
                model = new RavenJTokenCallbackModel<T> { Token = source, Index = 0 };
                model.Value = JsonConvert.DeserializeObject<T>(Update(model).ToString());
                callback(model);
            }

            return true;
        }
    }
}
