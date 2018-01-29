using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Historisation.Models
{
    public class Compte
    {
        public String login { get; set; }
        public String nom { get; set; }
        public String prenom { get; set; }
        public String email { get; set; }
        public String tel { get; set; }
        public String description { get; set; }
    }
}