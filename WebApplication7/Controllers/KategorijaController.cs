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
    public class KategorijaController : Controller
    {
        private BazaDbContext baza = new BazaDbContext();
        public ActionResult Index()
        {
            ViewBag.Title = "Baza kategorija";
            return View();
        }
        public ActionResult PopisKategorija(string naziv, string kategorija)
        {
            List<KategorijaModel> popis = baza.Kategorije.ToList();

            if (!String.IsNullOrEmpty(naziv))
            {
                popis = popis.Where(
                       st => (st.naziv_kategorije).ToUpper().
                           Contains(naziv.ToUpper())).
                           OrderBy(st => st.naziv_kategorije).ToList();
            }
            ViewBag.Title = "Popis kategorija";
            return View(popis);
        }


        [HttpGet]
        public ActionResult DodavanjeKategorija(int? id)
        {
            KategorijaModel k;
            if (id == null)
            {
                k = new KategorijaModel();
            }
            else
            {
                k = baza.Kategorije.Find(id);
                if (k == null)
                {
                    return HttpNotFound();
                }
            }

            List<KategorijaModel> kategorija = baza.Kategorije.ToList();
            kategorija.Add(new KategorijaModel { naziv_kategorije = "Nedefinirano" });
            ViewBag.Kategorije = kategorija;
            ViewBag.Title = "Dodavanje nove kategorije";
            return View(k);
        }


        [HttpPost]
        public ActionResult DodavanjeKategorija(KategorijaModel k)
        {

            if (ModelState.IsValid)
            {
                if (k.id_kategorija != 0)
                {
                    // ažuriranje

                    baza.Entry(k).State =
                        EntityState.Modified;

                }
                else
                {
                    // upis
                    baza.Kategorije.Add(k);

                }

                baza.SaveChanges();

                return RedirectToAction("PopisKategorija");
            }
            List<KategorijaModel> kategorija = baza.Kategorije.ToList();
            kategorija.Add(new KategorijaModel { naziv_kategorije = "Nedefinirano" });
            ViewBag.Kategorije = kategorija;
            ViewBag.Title = "Dodavanje nove kategorije";
            return View(k);
        }
        [HttpGet]
        public ActionResult UrediKategoriju(int id)
        {

            KategorijaModel k = new KategorijaModel();
            foreach (KategorijaModel kat in baza.Kategorije)
            {
                if (kat.id_kategorija == id)
                {

                    k = kat;
                }
            }

            if (k == null)
            {
                return HttpNotFound();

            }
            if (Request.IsAjaxRequest())

            {
                ViewBag.IsUpdate = false;

                return View("UrediKategoriju", k);
            }
            else
                return View("UrediKategoriju", k);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult UrediKategoriju([Bind(Include = "id_kategorija, naziv_kategorije")] KategorijaModel kat)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("UrediKategoriju", kat);

            }

            KategorijaModel K = baza.Kategorije.Where(

             x => x.id_kategorija == kat.id_kategorija).SingleOrDefault();

            if (kat.id_kategorija != 0 && K != null)
            {
                baza.Entry(K).CurrentValues.SetValues(kat);
            }
            else
            {
                baza.Kategorije.Add(kat);
            }
            baza.SaveChanges();
            if (Request.IsAjaxRequest())
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);

            }
            return RedirectToAction("PopisKategorija");
        }


        public ActionResult ObrisiKategoriju(int id)
        {
            KategorijaModel kategorija = baza.Kategorije.Find(id);
            if (Request.IsAjaxRequest())
            {
                ViewBag.IsUpdate = false;
                return View("ObrisiKategoriju", kategorija);
            }
            else

                return View("ObrisiKategoriju", kategorija);
        }

        [HttpPost, ActionName("ObrisiKategoriju")]
        [ValidateAntiForgeryToken]
        public ActionResult ObrisiKategoriju1(int id)
        {
            KategorijaModel K = baza.Kategorije.Where(
              x => x.id_kategorija == id).SingleOrDefault();
            List<OglasModel> oglasi = baza.Oglasi.Where(o => o.id_kategorija == id).ToList();
            if (oglasi != null)
            {
                foreach (OglasModel og in oglasi)
                {
                    baza.Oglasi.Remove(og);
                    baza.SaveChanges();
                }
            }
                if (K != null)
            {
                baza.Kategorije.Remove(K);
                baza.SaveChanges();
            }
            if (Request.IsAjaxRequest())
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }

            return RedirectToAction("PopisKategorija");
        }
    }

}
