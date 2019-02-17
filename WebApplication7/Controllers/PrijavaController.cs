using Akcija_prodaja.BazaContext;
using Akcija_prodaja.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI;
using WebApplication7.Controllers;

namespace WebApplication7.Controllers
{
    public class PrijavaController : Controller
    {
        private BazaDbContext baza = new BazaDbContext();
       
        [HttpGet]
        public ActionResult Prijava()
        {


            Sesija.Tren.KorisnikId = 0;
            KorisnikModel kor = new KorisnikModel();

            return View(kor);
        }

        [HttpPost]
        public ActionResult Prijava(KorisnikModel k)
        {

            KorisnikModel korisnik = baza.Korisnici.SingleOrDefault(kor => kor.email == k.email && kor.lozinka == k.lozinka);
           

            if (korisnik != null)
            {
                Sesija.Tren.KorisnikId = korisnik.id_korisnik;
                return RedirectToAction("PocetnaStranica", "Pocetna");
            }

            else
            {
                {

                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
                    Response.Cache.SetNoStore();
                    FormsAuthentication.SignOut();
                    return View("Prijava");
                }
            }
        }

        [HttpPost]
        public ActionResult Odjava1()
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
            Response.Cache.SetNoStore();

            FormsAuthentication.SignOut();
            return View("Prijava");

        }

    }
}
