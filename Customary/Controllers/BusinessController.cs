using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Custom.Controllers
{
    public class BusinessController : Controller
    {

        //
        // GET: /Business/Contact

        public ActionResult Contact()
        {
            return View();
        }

        //
        // GET: /Business/Dashboard

        public ActionResult Dashboard()
        {
            return View();
        }

        //
        // GET: /Business/Index

        /// <summary>
        /// Tree view for Domain and Segments
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Business/List

        /// <summary>
        /// List
        /// </summary>
        /// <returns></returns>
        public ActionResult List()
        {
            return View();
        }

        //
        // GET: /Business/Model

        /// <summary>
        /// Model
        /// </summary>
        /// <returns></returns>
        public ActionResult Model()
        {
            return View();
        }

        //
        // GET: /Business/Object

        public ActionResult Object()
        {
            return View();
        }

        //
        // GET: /Business/Type

        public ActionResult Type()
        {
            return View();
        }

        //
        // GET: /Business/Unit

        public ActionResult Unit()
        {
            return View();
        }
    }
}
