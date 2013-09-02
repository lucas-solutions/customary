using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Controllers
{
    using Custom.Metadata;

    /// <summary>
    /// Sencha ExtJs Controller
    /// </summary>
    public abstract class ExtController : CustomController
    {
        protected ActionResult Data(Guid? id, TypeDescriptor entity)
        {
            object data = null;

            switch (entity.MemberType)
            {
                case MemberTypes.Entity:
                    break;

                case MemberTypes.Enum:
                    break;

                default:
                    // error
                    break;
            }

            return Json(data);
        }

        protected ActionResult Form(string id)
        {
            return PartialView();
        }

        protected ActionResult Grid(string id)
        {
            return PartialView();
        }

        protected JsonResult List(string id)
        {
            return Json(new object());
        }

        protected ActionResult Model(EntityDescriptor entity)
        {
            object model = null;

            return PartialView(model);
        }

        protected ActionResult Panel(string id)
        {
            return PartialView();
        }

        protected ActionResult Store(string id)
        {
            object model = null;

            switch (id.Trim().ToLower())
            {
                case "navigation":
                    break;

                default:
                    model = null;
                    break;
            }

            return PartialView(model);
        }

        protected ActionResult Tree(string id)
        {
            return PartialView();
        }

        protected ActionResult TreeGrid(string id)
        {
            return PartialView();
        }
    }
}
