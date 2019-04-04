using Akcija_prodaja.BazaContext;
using Akcija_prodaja.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace WebApplication7.Controllers
{
    public class OglasController : Controller
    {
        private BazaDbContext baza = new BazaDbContext();
        private const string TempPath = @"C:\Users\Tin\Radna površina";

        public ActionResult Oglas()
        {

            ViewBag.Title = "Baza oglasa";
            return View();
        }
        
        public ActionResult PopisOglasa()
        {
            List<oglas_kategorija> oglasi = new List<oglas_kategorija>();

            List<ArtiklModel> artikls = baza.Artikli.ToList();
            List<KategorijaModel> kategorije = baza.Kategorije.ToList();
      
            foreach (OglasModel k in baza.Oglasi)
            {
                KategorijaModel data = kategorije.Where(ka => ka.id_kategorija == k.id_kategorija).SingleOrDefault();
                ArtiklModel data1 = artikls.Where(ar => ar.id_artikl == k.id_artikl).SingleOrDefault();
                oglas_kategorija podatak = new oglas_kategorija();
                podatak.oglas = k;
                podatak.kategorija = data.naziv_kategorije;
                podatak.artikl = data1.naziv_artikl;
                oglasi.Add(podatak);

            }



            return View(oglasi);
        }
       
        private bool TraziKorisnike(KorisnikModel k)
        {
            return false;
        }

       
        [HttpGet]
        public ActionResult DodavanjeOglasa(int? id)
        {
            OglasModel o;
            if (id == null)
            {
                o = new OglasModel();
            }
            else
            {
                o = baza.Oglasi.Find(id);
                if (o == null)
                {
                    return HttpNotFound();
                }
            }

            List<OglasModel> oglas = baza.Oglasi.ToList();
            oglas.Add(new OglasModel { kratki_opis = "Nedefinirano" });
            ViewBag.Oglas = oglas;
            ViewBag.Title = "Dodavanje novog oglasa";
            List<KategorijaModel> kategorije = baza.Kategorije.ToList();
            List<PoduzeceModel> poduzeca = baza.Poduzeca.ToList();
            List<AkcijaModel> akcije = baza.Akcije.ToList();
            List<ArtiklModel> artikli = baza.Artikli.ToList();
            List<Object> kat = new List<object>();
            List<Object> pod = new List<object>();
            List<Object> akc = new List<object>();
            List<Object> art = new List<object>();
            foreach (KategorijaModel k in kategorije)
            {
                kat.Add(new {value=k.id_kategorija,text=k.naziv_kategorije });
            }
            foreach (PoduzeceModel p in poduzeca)
            {
                pod.Add(new { value = p.id_poduzece, text = p.naziv_poduzece });
            }
            foreach (AkcijaModel a in akcije)
            {
                akc.Add(new { value = a.id_akcija, text = a.naziv_akcija });
            }
            foreach(ArtiklModel ar in artikli)
            {
                art.Add(new { value = ar.id_artikl, text = ar.naziv_artikl });
            }
            ViewBag.Poduzeca = pod;
            ViewBag.Kategorije = kat;
            ViewBag.Akcije = akc;
            ViewBag.Artikli = art;
            return View(o);

        }


        [HttpPost]
        public ActionResult DodavanjeOglasa(OglasModel o)
        {
            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];


                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    o.slika_proizvoda = fileName;
                    var path = Path.Combine(Server.MapPath("~/Images/"), fileName);
                    file.SaveAs(path);
                }
            }
            var allowed = new[] { ".jpeg", ".png" };
            var extesions = Path.GetExtension(TempPath);

            if (o.osnovna_cijena < 0 && o.postotak_popusta < 0 && o.akcijska_cijena < 0)
            {
                TempData["Error"] = "error message";
            }
            else
            {
                if (ModelState.IsValid)
                {
                    if (o.id_oglas != 0)
                    {
              
                        baza.Entry(o).State =
                            EntityState.Modified;

                    }
                    else
                    {

                     
                        baza.Oglasi.Add(o);
                    }


                    baza.SaveChanges();


                    return RedirectToAction("PopisOglasa");
                }

                List<OglasModel> oglas = baza.Oglasi.ToList();
       
                ViewBag.Oglas = oglas;
                ViewBag.Title = "Dodavanje novog oglasa";
            }
            
            return View(o);
        }

        public ActionResult Obrisi(int id)
        {
            OglasModel oglas = baza.Oglasi.Find(id);
            if (Request.IsAjaxRequest())
            {
                ViewBag.IsUpdate = false;
                return View("Obrisi", oglas);
            }
            else

                return View("Obrisi", oglas);
        }

        [HttpPost, ActionName("Obrisi")]
        [ValidateAntiForgeryToken]
        public ActionResult Obrisi1(int id)
        {
            OglasModel O = baza.Oglasi.Where(
              x => x.id_oglas == id).SingleOrDefault();

            if (O != null)
            {
                baza.Oglasi.Remove(O);
                baza.SaveChanges();
            }
            if (Request.IsAjaxRequest())
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }

            return RedirectToAction("PopisOglasa");
        }


    }

}