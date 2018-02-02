using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Historisation.Models
{
    public class Pause
    {
        public int id { get; set; }
        public String type { get; set; }
        public DateTime h_debut { get; set; }
        public DateTime h_fin { get; set; }
    }
}