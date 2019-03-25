using Akcija_prodaja.BazaContext;
using Akcija_prodaja.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace WebApplication7.Controllers
{
    public class ArtiklController : Controller
    {
        BazaDbContext baza = new BazaDbContext();
        public ActionResult Index()
        {

            ViewBag.Title = "Baza artikl";
            return View();
        }

        public ActionResult PopisArtikala(string naziv)
        {
            List<ArtiklModel> popis = baza.Artikli.ToList();

            if (!String.IsNullOrEmpty(naziv))
            {
                popis = popis.Where(
                       st => (st.naziv_artikl).ToUpper().
                           Contains(naziv.ToUpper())).
                           OrderBy(st => st.naziv_artikl).ToList();
            }
            ViewBag.Title = "Popis artikala";
            return View(popis);
        }


        [HttpGet]
        public ActionResult DodavanjeArtikla(int? id)
        {
            ArtiklModel a;
            if (id == null)
            {
                a = new ArtiklModel();
            }
            else
            {
                a = baza.Artikli.Find(id);
                if (a == null)
                {
                    return HttpNotFound();
                }
            }
            List<ArtiklModel> artikli = baza.Artikli.ToList();
            artikli.Add(new ArtiklModel { naziv_artikl = "Nedefinirano" });

            ViewBag.Title = "Dodavanje novog artikla";
      

            return View(a);
        }


        [HttpPost]
        public ActionResult DodavanjeArtikla(ArtiklModel a)
        {
            if (ModelState.IsValid)
            {
                if (a.id_artikl != 0)
                {
                    // ažuriranje

                    baza.Entry(a).State =
                        EntityState.Modified;

                }
                else
                {
                    baza.Artikli.Add(a);

                }

                baza.SaveChanges();
                return RedirectToAction("PopisArtikala");
            }

            List<ArtiklModel> artikli= baza.Artikli.ToList();
            artikli.Add(new ArtiklModel { naziv_artikl = "Nedefinirano" });
            ViewBag.Artikli  = artikli;
            ViewBag.Title = "Dodavanje novog artikla";
            return View(a);
    
        }

        [HttpGet]
        public ActionResult UrediArtikl(int id)
        {

            ArtiklModel a = new ArtiklModel();
            foreach (ArtiklModel art in baza.Artikli)
            {
                if (art.id_artikl == id)
                {

                    a = art;
                }
            }

            if (a == null)
            {
                return HttpNotFound();

            }
            if (Request.IsAjaxRequest())

            {
                ViewBag.IsUpdate = false;

                return View("UrediArtikl", a);
            }
            else
                return View("UrediArtikl", a);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult UrediArtikl([Bind(Include = "id_artikl, naziv_artikl,cijena_artikl")] ArtiklModel art)
        {
            if (!ModelState.IsValid)
            {
                return View("UrediArtikl", art);

            }

            ArtiklModel A = baza.Artikli.Where(

             x => x.id_artikl == art.id_artikl).SingleOrDefault();

            if (art.id_artikl != 0 && A != null)
            {
                baza.Entry(A).CurrentValues.SetValues(art);
            }
            else
            {
                baza.Artikli.Add(art);
            }
            baza.SaveChanges();
            if (Request.IsAjaxRequest())
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);

            }
            return RedirectToAction("PopisArtikala");
        }

        public ActionResult ObrisiArtikl(int id)
        {
            ArtiklModel art = baza.Artikli.Find(id);
            if (Request.IsAjaxRequest())
            {
                ViewBag.IsUpdate = false;
                return View("ObrisiArtikl", art);
            }
            else

                return View("ObrisiArtikl", art);
        }

        [HttpPost, ActionName("ObrisiArtikl")]
        [ValidateAntiForgeryToken]
        public ActionResult ObrisiArtikl1(int id)
        {
            ArtiklModel A = baza.Artikli.Where(
              x => x.id_artikl == id).SingleOrDefault();

            if (A != null)
            {
                baza.Artikli.Remove(A);
                baza.SaveChanges();
            }
            if (Request.IsAjaxRequest())
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }

            return RedirectToAction("PopisArtikala");
        }
    }

}
