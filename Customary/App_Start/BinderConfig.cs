using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom
{
    public class BinderConfig
    {
        public static void RegisterBinders(ModelBinderDictionary binders)
        {
            binders.Add(typeof(Custom.Models.Sort), new Custom.Binders.SortBinder());
            binders.Add(typeof(IEnumerable<Custom.Models.Sort>), new Custom.Binders.SortBinder());
            binders.Add(typeof(Custom.Models.Sort[]), new Custom.Binders.SortBinder());
            binders.Add(typeof(List<Custom.Models.Sort>), new Custom.Binders.SortBinder());
            binders.Add(typeof(Collection<Custom.Models.Sort>), new Custom.Binders.SortBinder());
        }
    }
}