using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom
{
    using Custom.Models;

    public class BinderConfig
    {
        public static void RegisterBinders(ModelBinderDictionary binders)
        {
            binders.Add(typeof(App), new Binders.ApplicationBinder());
            binders.Add(typeof(Area), new Binders.AreaBinder());
            binders.Add(typeof(Field), new Binders.FieldBinder());
            binders.Add(typeof(File), new Binders.FileBinder());
            binders.Add(typeof(Item), new Binders.ItemBinder());
            binders.Add(typeof(List), new Binders.ListBinder());
            binders.Add(typeof(Grid), new Binders.GridBinder());
            binders.Add(typeof(Note), new Binders.NoteBinder());
            binders.Add(typeof(Column), new Binders.ColumnBinder());
            binders.Add(typeof(Form), new Binders.FormBinder());
        }
    }
}