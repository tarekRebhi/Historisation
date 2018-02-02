using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Historisation.Models
{
    public class Historisation
    {
        public int id { get; set; }
        public String poles { get; set; }
        public String sites { get; set; }
        public String mission { get; set; }
        public int nombre { get; set; }
        public String metier { get; set; }
        public String tache { get; set; }
        public DateTime d_debut { get; set; }
        public DateTime d_fin { get; set; }
        public String duree { get; set; }

    }
}