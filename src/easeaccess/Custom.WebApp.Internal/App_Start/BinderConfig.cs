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
            
            binders.Add(typeof(Area), new Binders.AreaBinder());
            binders.Add(typeof(Column), new Binders.ColumnBinder());
            binders.Add(typeof(Field), new Binders.FieldBinder());
            binders.Add(typeof(File), new Binders.FileBinder());
            binders.Add(typeof(Model), new Binders.FormBinder());
            binders.Add(typeof(Grid), new Binders.GridBinder());
            binders.Add(typeof(Item), new Binders.ItemBinder());
            binders.Add(typeof(List), new Binders.ListBinder());
            binders.Add(typeof(Note), new Binders.NoteBinder());
            
            // after area binding, so it doesn't bind area to app
            binders.Add(typeof(App), new Binders.ApplicationBinder());
        }
    }
}