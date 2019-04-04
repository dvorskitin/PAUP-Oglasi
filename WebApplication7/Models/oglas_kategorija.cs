using Akcija_prodaja.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Akcija_prodaja.Models
{
    public class oglas_kategorija
    {
        public OglasModel oglas { get; set; }

        [DisplayName("Kategorija")]
        public string kategorija { get; set; }

        [DisplayName("artikl")]
        public string artikl { get; set; }
    }
}