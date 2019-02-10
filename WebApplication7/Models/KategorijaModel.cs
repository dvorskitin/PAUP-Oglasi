using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication7.Models
{
    [Table("kategorija")]
    public class KategorijaModel
    {
        [Key]
        public int id_kategorija {get; set;}

        public string naziv_kategorija { get; set; }

    }
}