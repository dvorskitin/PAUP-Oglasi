using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Akcija_prodaja.Models
{
    [Table("kategorija")]
    public class KategorijaModel
    {
        [Key]
        [Required]
        [DisplayName("ID kategorije")]
        public int id_kategorija {get; set;}

        [DisplayName("Naziv kategorije")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        public string naziv_kategorije { get; set; }

    }
}