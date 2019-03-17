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
    public class AkcijaController : Controller
    {
        BazaDbContext baza = new BazaDbContext();
        public ActionResult Index()
        {

            ViewBag.Title = "Baza akcija";
            return View();
        }
        public ActionResult PopisAkcija(string naziv, string kategorija)
        {
            List<AkcijaModel> popis = baza.Akcije.ToList();

            if (!String.IsNullOrEmpty(naziv))
            {
                popis = popis.Where(
                       st => (st.naziv_akcija).ToUpper().
                           Contains(naziv.ToUpper())).
                           OrderBy(st => st.naziv_akcija).ToList();
            }
            ViewBag.Title = "Popis akcija";
            return View(popis);
        }


        [HttpGet]
        public ActionResult DodavanjeAkcija(int? id)
        {
            AkcijaModel a;
            if (id == null)
            {
                a = new AkcijaModel();
            }
            else
            {
                a = baza.Akcije.Find(id);
                if (a == null)
                {
                    return HttpNotFound();
                }
            }
            List<AkcijaModel> akcija = baza.Akcije.ToList();

            akcija.Add(new AkcijaModel { naziv_akcija = "Nedefinirano" });
            ViewBag.Akcije = akcija;
            ViewBag.Title = "Dodavanje nove akcije";
            List<PoduzeceModel> poduzeca = baza.Poduzeca.ToList();
            List<AkcijaModel> akcije = baza.Akcije.ToList();
            List<Object> pod = new List<object>();
            foreach (PoduzeceModel p in poduzeca)
            {
                pod.Add(new { value = p.id_poduzece, text = p.naziv_poduzece });
            }

            ViewBag.Poduzeca = pod;
            return View(a);
        }


        [HttpPost]
        public ActionResult DodavanjeAkcija(AkcijaModel a)
        {
            //int veci = DateTime.Compare(a.datum_pocetka, a.datum_zavrsetka);
            //if (veci > 0)
            //    ModelState.AddModelError("datum_zavrsetka", "Datum početka mora biti veći od datuma završetka");


            if (ModelState.IsValid)
            {
                

                if (a.id_akcija != 0)
                {
                    // ažuriranje
                  
                    baza.Entry(a).State =
                        EntityState.Modified;

                }
                else
                {
                    baza.Akcije.Add(a);

                }

                baza.SaveChanges();

                return RedirectToAction("PopisAkcija");
            }
            List<AkcijaModel> akcije = baza.Akcije.ToList();
            akcije.Add(new AkcijaModel { naziv_akcija = "Nedefinirano" });
            ViewBag.Akcije = akcije;
            ViewBag.Title = "Dodavanje nove akcije";
            return View(a);
        }



        [HttpGet]
        public ActionResult UrediAkciju(int id)
        {

            AkcijaModel a = new AkcijaModel();
            foreach (AkcijaModel akc in baza.Akcije)
            {
                if (akc.id_akcija == id)
                {

                    a = akc;
                }
            }

            if (a == null)
            {
                return HttpNotFound();

            }
            if (Request.IsAjaxRequest())

            {
                ViewBag.IsUpdate = false;

                return View("UrediAkciju", a);
            }
            else
                return View("UrediAkciju", a);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult UrediAkciju([Bind(Include = "id_poduzece, id_akcija, id_oglas, naziv_akcija, datum_pocetka, datum_zavrsetka , datum_zavrsetka,opis")] AkcijaModel akc)
        {
            if (!ModelState.IsValid)
            {
                return View("UrediAkciju", akc);

            }

            AkcijaModel A = baza.Akcije.Where(

             x => x.id_akcija == akc.id_akcija).SingleOrDefault();

            if (akc.id_akcija != 0 && A != null)
            {
                baza.Entry(A).CurrentValues.SetValues(akc);
            }
            else
            {
                baza.Akcije.Add(akc);
            }
            baza.SaveChanges();
            if (Request.IsAjaxRequest())
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);

            }
            return RedirectToAction("PopisAkcija");
        }

        public ActionResult ObrisiAkciju(int id)
        {
            AkcijaModel akc = baza.Akcije.Find(id);
            if (Request.IsAjaxRequest())
            {
                ViewBag.IsUpdate = false;
                return View("ObrisiAkciju", akc);
            }
            else

                return View("ObrisiAkciju", akc);
        }

        [HttpPost, ActionName("ObrisiAkciju")]
        [ValidateAntiForgeryToken]
        public ActionResult ObrisiAkciju1(int id)
        {
            AkcijaModel A = baza.Akcije.Where(
              x => x.id_akcija == id).SingleOrDefault();

            if (A != null)
            {
                baza.Akcije.Remove(A);
                baza.SaveChanges();
            }
            if (Request.IsAjaxRequest())
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }

            return RedirectToAction("PopisAkcija");
        }
    }
}