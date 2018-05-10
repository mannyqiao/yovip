using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Enjoy.Portal.Dashboard.Models;

namespace Enjoy.Portal.Dashboard.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(new Portals() );
        }       
        public ActionResult Logon()
        {
            return View();
        }
        public ActionResult Registry()
        {
            return View();
        }
        public ActionResult Start()
        {
            return View();
        }
    }
}