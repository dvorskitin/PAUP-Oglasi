using Akcija_prodaja.BazaContext;
using Akcija_prodaja.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Akcija_prodaja.Controllers
{
    public class PrijavaController : Controller
    {
        private BazaDbContext baza = new BazaDbContext();
       
        [HttpGet]
        public ActionResult Prijava()
        {

           

            KorisnikModel kor = new KorisnikModel();

            return View(kor);
        }

        [HttpPost]
        public ActionResult Prijava(KorisnikModel k)
        {
           
            KorisnikModel korisnik = baza.Korisnici.SingleOrDefault(kor => kor.email == k.email && kor.lozinka == k.lozinka);


            if (korisnik != null)
            {
                return RedirectToAction("PocetnaStranica","Pocetna");
            }
            
            else
            {
                return View("Prijava");
            }
        }
    }
}