using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using krotkiProjekt.Models;

namespace krotkiProjekt.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            var db = new MyDb();
            return View("Index", db.Autorzy.ToList());
        }
        public ActionResult Partial_Detale_A(int id_a)
        {
            var db = new MyDb();
            var ksiazki = db.Autorzy.Join(db.Asocjacja, 
                    aut => aut.Id_A, 
                    asoc => asoc.Id_A, 
                    (aut, asoc) => new { aut.Id_A, asoc.Id, asoc.Id_K })
                .Join(db.Ksiazki, 
                    tmp1 => tmp1.Id_K, 
                    k => k.Id_K, 
                    (tmp1, k) => new { tmp1.Id_A, tmp1.Id_K, k.Tytul, k.Opis, k.Data_wydania})
                .Where(c=>c.Id_A == id_a)
                .ToList();// tu jest wazna kolejność
            return PartialView("Partial_Detale_A", ksiazki);
        }

        public ActionResult Detale_A(int id_a)
        {
            var db = new MyDb();
            return View("Detale", db.Autorzy.Find(id_a));
        }
    }
}
