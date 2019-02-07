using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Akcija_prodaja.Models
{
    public class PrijavaModel
    {
        [Required(ErrorMessage = "{0} je obavezan")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string email { get; set; }


        [Required(ErrorMessage = "{0} je obavezna")]
        [DataType(DataType.Password)]
        public string lozinka { get; set; }

    }
}