using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Custom.Presentation
{
    public class JField<TModel> : JObject<TModel>, IScriptable
        where TModel : class
    {
        IScriptable _parent;

        public JField()
        {
        }

        public void Assign(JObject<TModel> other)
        {
            Name = other.Name;
            Model = other.Model;
        }

        #region - IScriptable -

        bool IScriptable.IsEmpty
        {
            get
            {
                var scriptable = Model as IScriptable;

                if (scriptable != null)
                    return false;

                return string.IsNullOrEmpty(Name);
            }
        }

        string IScriptable.Template
        {
            get
            {
                var scriptable = Model as IScriptable;
                return scriptable != null ? scriptable.Template : null;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        void IScriptable.Script(ScriptWriter writer)
        {
            var name = Name ?? string.Empty;
            var scriptable = Model as IScriptable;
            if (scriptable != null)
                scriptable.Script(writer);
            else
                writer.Write("'" + name + "'");
        }

        #endregion - IScriptable -
    }
}