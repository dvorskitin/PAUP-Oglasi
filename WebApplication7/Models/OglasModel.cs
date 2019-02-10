using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Akcija_prodaja.Models
{
    [Table("oglas")]
    public class OglasModel
    {
        public int id_poduzece { get; set; }

        [Key]
        public int id_oglas { get; set; }

        public int id_akcija { get; set; }

        public string naziv_artikla { get; set; }

        public double osnovna_cijena { get; set; }

        public decimal mjerna_jedinica { get; set; }

        public decimal postotak_popusta { get; set; }

        public decimal akcijska_cijena { get; set; }

        public string kratki_opis { get; set; }

        public string dugi_opis { get; set; }

        public Byte[] slika_proizvoda { get; set; }

        public int id_kategorija { get; set; }

    }
}