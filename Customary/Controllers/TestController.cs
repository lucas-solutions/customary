﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Controllers
{
    using Custom.Diagnostics;
    using Custom.Models;

    public class TestController : Custom.Web.Mvc.CustomController
    {
        public TestController()
            : base("returnTo")
        {
        }

        public ActionResult Logger()
        {
            int intValue;

            foreach (var key in QueryString.AllKeys)
            {
                var value = QueryString[key];

                switch (key)
                {
                    case "category":
                        LogCategories category;
                        if (System.Enum.TryParse<Custom.Diagnostics.LogCategories>(value, out category))
                            base.Log.Category(category);
                        break;

                    case "class":
                        base.Log.Class(value);
                        break;

                    case "id":
                        if (int.TryParse(value, out intValue))
                            base.Log.ID(intValue);
                        break;

                    case "message":
                        base.Log.Message(value);
                        break;

                    case "method":
                        base.Log.Method(value);
                        break;

                    case "namespace":
                        base.Log.Namespace(value);
                        break;

                    default:
                        break;
                }
            }

            return View((Dictionary<string, object>)base.Log);
        }

        //
        // GET: /Test/

        public ActionResult Redirect()
        {
            int sessionID = (int)Identification.Get<int>("SessionID");
            if (sessionID == 0)
            {
                sessionID = new Random().Next();
                Identification.Set<int>("SessionID", sessionID);
            }
            int hitCount = Identification.Get<int>("HitCount");
            Identification.Set<int>("HitCount", hitCount + 1);
            return View(new Models.RedirectModel
                {
                    SessionID = Identification.Get<int>("SessionID"),
                    HitCount = Identification.Get<int>("HitCount"),
                    Param = base.RedirectParam,
                    Url = base.QueryString[base.RedirectParam],
                    OriginalUrl = Request.Url.OriginalString,
                    QueryString = base.QueryString
                });
        }

        public ActionResult MapPath(string path)
        {
            string fullPath;
            var succeeded = Utils.PathHelper.TryGetFullPath(path, out fullPath);

            return View(new MapPathModel
                {
                    Path = path,
                    FullPath = fullPath,
                    Succeeded = succeeded ? "True" : "False"
                });
        }
    }
}
