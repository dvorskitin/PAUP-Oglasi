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
    public class HomeController : Controller
    {

        private BazaDbContext baza = new BazaDbContext();

        public ActionResult Index()
        {
            List<PoduzeceModel> popis = baza.Poduzeca.ToList();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}