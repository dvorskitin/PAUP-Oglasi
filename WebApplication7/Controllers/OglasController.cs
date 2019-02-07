//using Akcija_prodaja.BazaContext;
//using Akcija_prodaja.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//namespace WebApplication7.Controllers
//{
//    public class OglasController : Controller
//    {
//        private BazaDbContext baza = new BazaDbContext();

//        public ActionResult Oglas()
//        {

//            ViewBag.Title = "Baza oglasa";
//            return View();
//        }

//        public ActionResult PopisOglasa()
//        {
//            return View(baza.Oglasi);
//        }

//        private bool TraziKorisnike(OglasModel o)
//        {
//            return false;
//        }


//        public ActionResult PopisOglasa(int id, string oglas)
//        {
//            List<OglasModel> popis = baza.Oglasi.ToList();

//            if (id==0)
//            {
//                popis = popis.Where(
//                           st => (st.id_oglas).ToString().
//                               Contains(id.ToString())).
//                               OrderBy(st => st.id_oglas).ToList();
//            }

//                ViewBag.Title = "Popis oglasa";
//            return View(popis);
//        }
            
//    }
//}