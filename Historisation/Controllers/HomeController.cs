using Historisation.Models;
using System;
using System.Web.Mvc;
using System.DirectoryServices;
using System.Text;

namespace Historisation.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Test(PersonModel person)
        {
            
            string login = person.login;
            string password = person.password;
            try
            {
                // Connexion à l'annuaire
                DirectoryEntry Ldap = new DirectoryEntry("LDAP://info.local", person.login, person.password);
                // Nouvel objet pour instancier la recherche
                DirectorySearcher searcher = new DirectorySearcher(Ldap);
                // On modifie le filtre pour ne chercher que l'user 
                searcher.Filter = "(&(objectClass=user)(sAMAccountName=" + person.login + "))";
                // Pas de boucle foreach car on ne cherche qu'un user
                SearchResult result = searcher.FindOne();
                // On récupère l'objet trouvé lors de la recherche
                DirectoryEntry DirEntry = result.GetDirectoryEntry();
                ViewBag.value = DirEntry.Properties["mail"].Value;
                //ViewBag.message = "Compte existant !";

                /*searcher.Filter = String.Format("(cn={0})", person.login);
                searcher.PropertiesToLoad.Add("memberOf");*/
                StringBuilder groupsList = new StringBuilder();
                string[] msg;
                string[] msg2;


                if (result != null)
                {
                    int groupCount = result.Properties["memberOf"].Count;

                    for (int counter = 0; counter < groupCount; counter++)
                    {
                        groupsList.Append(DirEntry.Properties["memberOf"][counter]);
                        groupsList.Append("|");
                        msg = groupsList.ToString().Split('|');
                        msg2 = msg[counter].Split(',');
                        //ViewBag.msg += msg[counter];
                        ViewBag.msg2 +=msg2[0]+" " +" | ";

                    }
                }
                //groupsList.Length -= 1; //remove the last '|' symbol
                //ViewBag.gr=groupsList.ToString();
                
                
                
                
            }
            


            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
                ViewBag.message = Ex;


            }
            
            return View("~/Views/Home/test.cshtml");

}

        
    }
}