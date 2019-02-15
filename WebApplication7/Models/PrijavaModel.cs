using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Akcija_prodaja.Models
{
    public class PrijavaModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [DisplayName("E-mail adresa")]
        public string email { get; set; }



        [DisplayName("Lozinka")]
        [DataType(DataType.Password)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak")]
        public string lozinka { get; set; }

    }
}