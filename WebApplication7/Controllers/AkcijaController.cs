using Akcija_prodaja.BazaContext;
using Akcija_prodaja.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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

            if (ModelState.IsValid)
            {

                if (a.id_akcija != 0)
                {
                    // ažuriranje
                    if (a.datum_pocetka < a.datum_zavrsetka)
                        throw new Exception("Datum početka mora biti veći od datuma završetka!");
                    baza.Entry(a).State =
                        EntityState.Modified;

                }
                else
                {
                    if (a.datum_pocetka < a.datum_zavrsetka)
                        throw new Exception("Datum početka mora biti veći od datuma završetka!");
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
    }
}