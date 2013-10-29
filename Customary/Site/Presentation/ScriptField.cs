using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Custom.Site.Presentation
{
    public class ScriptField<TModel> : Scriptable
        where TModel : class
    {
        public static implicit operator ScriptField<TModel>(TModel model)
        {
            return new ScriptField<TModel> { Model = model };
        }

        public static implicit operator ScriptField<TModel>(string name)
        {
            return new ScriptField<TModel> { Name = name };
        }

        public static implicit operator TModel(ScriptField<TModel> field)
        {
            return field != null ? field.Model : null;
        }

        public static implicit operator string(ScriptField<TModel> field)
        {
            return field != null ? (!string.IsNullOrEmpty(field.Name) ? field.Name : (field.Model != null ? field.Model.ToString() : null)) : null;
        }

        public ScriptField()
        {
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

        public void Assign(ScriptField<TModel> other)
        {
            Name = other.Name;
            Model = other.Model;
        }

        public override void Render(List<string> lines)
        {
            var model = Model;
            var scriptable = model as IScriptable;

            if (scriptable != null)
                scriptable.Render(lines);
            else if (!RenderObject(model, null, lines))
            {
                var name = Name;
                if (!string.IsNullOrWhiteSpace(name))
                    lines.Append('"' + name + '"');
            }
        }
    }
}