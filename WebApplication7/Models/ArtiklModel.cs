using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Akcija_prodaja.Models
{
    [Table("artikl")]
    public class ArtiklModel
    {
        [Key]
        [Required]
        [DisplayName("ID artikla")]
        public int id_artikl { get; set; }

     
        [DisplayName("Naziv artikla")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        public string naziv_artikl { get; set; }


        [DisplayName("Cijena artikla")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        public double cijena_artikl { get; set; }



    }
}