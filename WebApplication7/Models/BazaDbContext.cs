using Akcija_prodaja.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Akcija_prodaja.BazaContext
{
    public class BazaDbContext : DbContext
    {
        public DbSet<PoduzeceModel> Poduzeca { get; set; }

        public DbSet<KorisnikModel> Korisnici { get; set; }

        public DbSet<OglasModel> Oglasi { get; set; }

       




    }
}