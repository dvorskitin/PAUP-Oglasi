using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Akcija_prodaja.Models
{
    [Table("korisnik")]
    public class KorisnikModel
    {
        [Key]
        public int id_korisnik { get; set; }

        public int id_poduzece { get; set; }

        public string ime { get; set; }

        public string prezime { get; set; }

        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [DataType(DataType.Password)]
        public string lozinka { get; set; }

    }
}