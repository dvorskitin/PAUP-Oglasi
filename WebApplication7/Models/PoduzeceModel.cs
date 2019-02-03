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

        public string naziv_poduzece { get; set; }

        public string adresa { get; set; }

        public string grad { get; set; }

        [DataType(DataType.PhoneNumber)]
        public int telefon { get; set; }

        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        public string web_adresa { get; set; }
    }
}