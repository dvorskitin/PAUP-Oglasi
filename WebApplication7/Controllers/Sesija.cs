using Akcija_prodaja.BazaContext;
using Akcija_prodaja.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication7.Controllers;

namespace WebApplication7.Controllers
{
    public class Sesija
    {
        public int KorisnikId { get; set; }

        public static Sesija Tren
        {
            get
            {
                Sesija ses = (Sesija)HttpContext.Current.Session["id_korisnik"];
                HttpContext.Current.Session.Timeout = 60;
                if (ses == null)
                {
                    ses = new Sesija();
                    HttpContext.Current.Session["id_korisnik"] = ses;

                }
                return ses;
            }
        }

        public static void Odjava()
        {

            HttpContext.Current.Session.Clear();
            HttpContext.Current.Session.Abandon();
           
           
        }
    }
}