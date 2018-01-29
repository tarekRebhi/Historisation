using Historisation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.DirectoryServices;


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
                
                DirectoryEntry Ldap = new DirectoryEntry("LDAP://info.local", person.login, person.password);
                DirectorySearcher searcher = new DirectorySearcher(Ldap);
                searcher.Filter = "(cn=Tarek)";
                SearchResult result = searcher.FindOne();
                DirectoryEntry DirEntry = result.GetDirectoryEntry();
                ViewBag.value = DirEntry.Properties["pass"].Value;
                ViewBag.Login = "Compte existant !";

            }



            catch (Exception Ex)
            {
                Console.WriteLine(Ex.Message);
                ViewBag.Login = Ex;


            }
            
            return View("~/Views/Home/test.cshtml");

}

        
    }
}