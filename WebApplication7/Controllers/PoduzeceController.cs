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
    public class PoduzeceController : Controller
    {
        private BazaDbContext baza = new BazaDbContext();
        public ActionResult Index()
        {

            ViewBag.Title = "Baza poduzeca";
            return View();
        }

        public ActionResult PopisPoduzeca()
        {
            return View(baza.Poduzeca);
        }

        private bool TraziKorisnike(KorisnikModel k)
        {
            return false;
        }


        public ActionResult Popis(string naziv, string poduzece)
        {
            List<PoduzeceModel> popis = baza.Poduzeca.ToList();

            if (!String.IsNullOrEmpty(naziv))
            {
                popis = popis.Where(
                       st => (st.naziv_poduzece).ToUpper().
                           Contains(naziv.ToUpper())).
                           OrderBy(st => st.naziv_poduzece).ToList();
            }
            ViewBag.Title = "Popis poduzeca";
            return View(popis);
        }


        [HttpGet]
        public ActionResult DodavanjePoduzeca(int? id)
        {
            PoduzeceModel p;
            if (id == null)
            {
                p = new PoduzeceModel();
            }
            else
            {
                p = baza.Poduzeca.Find(id);
                if (p == null)
                {
                    return HttpNotFound();
                }
            }

            List<PoduzeceModel> poduzece = baza.Poduzeca.ToList();
            poduzece.Add(new PoduzeceModel {  naziv_poduzece= "Nedefinirano" });
            ViewBag.Poduzece = poduzece;
            ViewBag.Title = "Dodavanje novog poduzeca";
            return View(p);
        }


        [HttpPost]
        public ActionResult DodavanjePoduzeca(PoduzeceModel p)
        {

            if (ModelState.IsValid)
            {
                if (p.id_poduzece != 0)
                {
                    // ažuriranje

                    baza.Entry(p).State =
                        EntityState.Modified;
                }
                else
                {
                    // upis
                    baza.Poduzeca.Add(p);
                }
                baza.SaveChanges();
                return RedirectToAction("Popis");
            }
            List<PoduzeceModel> poduzece = baza.Poduzeca.ToList();
            poduzece.Add(new PoduzeceModel { naziv_poduzece = "Nedefinirano" });
            ViewBag.Poduzece = poduzece;
            ViewBag.Title = "Dodavanje novog poduzeca";
            return View(p);
        }

    }
}