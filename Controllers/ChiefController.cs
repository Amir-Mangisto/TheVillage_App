using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TheVillage_App.Controllers
{
    public class ChiefController : Controller
    {
        // GET: Chief
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ShowChief()
        {
            ViewBag.chief = "Welcom Chief Amir";
            return View();
        }
    }
}