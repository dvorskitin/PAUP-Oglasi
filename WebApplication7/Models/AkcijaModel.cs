using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Akcija_prodaja.Models
{
    [Table("akcija")]
    public class AkcijaModel
    {
        public int id_poduzece { get; set; }

        [Key]
        public int id_akcija { get; set; }

        public int id_oglas { get; set; }

        public string naziv_akcija { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime datum_pocetka { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime datum_zavrsetka { get; set; }

        public string opis { get; set; }
    }
}