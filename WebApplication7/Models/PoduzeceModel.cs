using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Akcija_prodaja.Models
{
    [Table("poduzece")]
    public class PoduzeceModel
    {
        [Key]
        [Required]
        public int id_poduzece { get; set; }

        [DataType(DataType.Text)]
        [Required(AllowEmptyStrings =false, ErrorMessage = "{0} je obavezan podatak")]
        public string naziv_poduzece { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        public string adresa { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        public string grad { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [DataType(DataType.PhoneNumber)]
        public int telefon { get; set; }

        [Required(AllowEmptyStrings= false, ErrorMessage = "{0} je obavezan podatak")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        public string web_adresa { get; set; }
    }
}