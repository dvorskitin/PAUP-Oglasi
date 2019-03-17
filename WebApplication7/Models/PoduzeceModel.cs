using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("ID poduzeća")]
        public int id_poduzece { get; set; }

        [DataType(DataType.Text)]
        [Required(AllowEmptyStrings =false, ErrorMessage = "{0} je obavezan podatak")]
        [DisplayName("Naziv poduzeća")]
        public string naziv_poduzece { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [DisplayName("Adresa")]
        public string adresa { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [DisplayName("Grad")]
        public string grad { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [DisplayName("Broj telefona")]
        public string telefon { get; set; }

        [Required(AllowEmptyStrings= false, ErrorMessage = "{0} je obavezan podatak")]
        [DisplayName("E-mail adresa")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [DisplayName("Web adresa")]
        public string web_adresa { get; set; }
    }
}