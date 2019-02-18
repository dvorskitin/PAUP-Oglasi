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
    public class KorisnikController : Controller
    {
        BazaDbContext baza = new BazaDbContext();
        public ActionResult Index()
        {
            ViewBag.Korisnici = "Baza korisnika";
            return View();
        }
        public ActionResult PopisKorisnika(string naziv, string korisnik)
        {
            List<KorisnikModel> popis = baza.Korisnici.ToList();

            if (!String.IsNullOrEmpty(naziv))
            {
                popis = popis.Where(
                       st => (st.ime).ToUpper().
                           Contains(naziv.ToUpper())).
                           OrderBy(st => st.ime).ToList();
            }
            ViewBag.Title = "Popis korisnika";
            return View(popis);
        }
        [HttpGet]
        public ActionResult DodavanjeKorisnika(int? id)
        {

            KorisnikModel k;
            if (id == null)
            {
                k = new KorisnikModel();
            }
            else
            {
                k = baza.Korisnici.Find(id);
                if (k == null)
                {
                    return HttpNotFound();
                }
            }
            List<PoduzeceModel> poduzeca = baza.Poduzeca.ToList();
            List<Object> pod = new List<object>();
            foreach (PoduzeceModel p in poduzeca)
            {
                pod.Add(new { value = p.id_poduzece, text = p.naziv_poduzece });
            }
            List<KorisnikModel> korisnici = baza.Korisnici.ToList();
            korisnici.Add(new KorisnikModel { ime = "Nedefinirano" });
            ViewBag.Korisnici = korisnici;
            ViewBag.Poduzeca = pod;
            ViewBag.Title = "Dodavanje novog korisnika";
            return View(k);
        }


        [HttpPost]
        public ActionResult DodavanjeKorisnika(KorisnikModel k)
        {

            if (ModelState.IsValid)
            {
                if (k.id_korisnik != 0)
                {
                    // ažuriranje

                    baza.Entry(k).State =
                        EntityState.Modified;

                }
                else
                {
                    // upis
                    baza.Korisnici.Add(k);

                }

                baza.SaveChanges();

                return RedirectToAction("PopisKorisnika");
            }
            List<KorisnikModel> korisnici = baza.Korisnici.ToList();
            korisnici.Add(new KorisnikModel { ime = "Nedefinirano" });
            ViewBag.Korisnici = korisnici;
            ViewBag.Title = "Dodavanje novog korisnika";
            return View(k);
        }

        [HttpGet]
        public ActionResult UrediKorisnika(int id)
        {

            KorisnikModel k = new KorisnikModel();
            foreach (KorisnikModel kor in baza.Korisnici)
            {
                if (kor.id_korisnik == id)
                {

                    k = kor;
                }
            }

            if (k == null)
            {
                return HttpNotFound();

            }
            if (Request.IsAjaxRequest())

            {
                ViewBag.IsUpdate = false;

                return View("UrediKorisnika", k);
            }
            else
                return View("UrediKorisnika", k);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult UrediKorisnika([Bind(Include = "id_korisnik,id_poduzece, ime,prezime, email, lozinka")] KorisnikModel kor)
        {
            if (!ModelState.IsValid)
            {
                return View("UrediKorisnika", kor);

            }

            KorisnikModel K = baza.Korisnici.Where(

             x => x.id_korisnik == kor.id_korisnik).SingleOrDefault();

            if (kor.id_korisnik != 0 && K != null)
            {
                baza.Entry(K).CurrentValues.SetValues(kor);
            }
            else
            {
                baza.Korisnici.Add(kor);
            }
            baza.SaveChanges();
            if (Request.IsAjaxRequest())
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);

            }
            return RedirectToAction("PopisKorisnika");
        }
    }
}