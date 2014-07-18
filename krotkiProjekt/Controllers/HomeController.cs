using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using krotkiProjekt;

namespace krotkiProjekt.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            var db = new MyDB();
            return View("Index"), db.Autorzy;
        }

    }
}
