using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Open_School_Library.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //Open_School_Library.Helpers.SeedExistingDatabase.seedDeweyTable();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}