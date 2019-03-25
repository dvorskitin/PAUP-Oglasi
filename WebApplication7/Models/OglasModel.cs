using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("ID oglasa")]
        public int id_oglas { get; set; }

        [DisplayName("ID akcije")]
        public int id_akcija { get; set; }

        [DisplayName("ID artikla")]
        public int id_artikl { get; set; }

        [DataType(DataType.Text)]
        [DisplayName("Naziv artikla")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak.")]
        public string naziv_artikla { get; set; }

        [DisplayName("Osnovna cijena")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak.")]
        public double osnovna_cijena { get; set; }

        [DisplayName("Mjerna jedinica")]
        [DataType(DataType.Text)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak.")]
        public string mjerna_jedinica { get; set; }

        [DisplayName("Postotka popusta")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak.")]
        public double postotak_popusta { get; set; }

        [DisplayName("Akcijska cijena")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak.")]
        public double akcijska_cijena { get; set; }

        [DisplayName("Kratki opis")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak.")]
        public string kratki_opis { get; set; }

        [DisplayName("Dugi opis")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak.")]
        public string dugi_opis { get; set; }

        [DisplayName("Slika proizvoda")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak.")]
        public string slika_proizvoda { get; set; }

        [DisplayName("ID kategorije")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} je obavezan podatak.")]
        public int id_kategorija { get; set; }



    }
}