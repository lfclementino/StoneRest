using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoneRest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "StoneRest";

            return RedirectToAction("Index", "Temperatures");
            //return View();
        }
    }
}
