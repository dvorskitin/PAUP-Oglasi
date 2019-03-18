using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Akcija_prodaja.Models
{
    [Table("akcija")]
    public class AkcijaModel
    {
        [DisplayName("ID poduzeca")]
        public int id_poduzece { get; set; }

        [Key]
        [DisplayName("ID akcije")]
        public int id_akcija { get; set; }

        [DisplayName("ID oglasa")]
        public int id_oglas { get; set; }

        [DisplayName("Naziv akcije")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        public string naziv_akcija { get; set; }

        [DataType(DataType.Date)]
        [DisplayName("Datum početka")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        public DateTime datum_pocetka { get; set; }

        [DataType(DataType.Date)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [DisplayName("Datum završetka")]
        public DateTime datum_zavrsetka { get; set; }

        [DisplayName("Opis")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        public string opis { get; set; }
    }
}