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
                    (aut, asoc) => new Temp1 
                        { Id_A=aut.Id_A, Id= asoc.Id, Id_K = asoc.Id_K })
                .Join(db.Ksiazki, 
                    tmp1 => tmp1.Id_K, 
                    k => k.Id_K, 
                    (tmp1, k) => new Temp2 
                        { Id_A=tmp1.Id_A, Id_K=tmp1.Id_K, Tytul=k.Tytul, Opis=k.Opis, Data_wydania=k.Data_wydania})
                .Where(c=>c.Id_A == id_a)
                .ToList();// tu jest wazna kolejność
            return PartialView("Partial_Detale_A", ksiazki);
        }

        public ActionResult Detale_A(int id_a)
        {
            var db = new MyDb();
            return View("Detale_A", db.Autorzy.Find(id_a));
        }
    }
}
