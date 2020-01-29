using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using TravelAgency.Models;

namespace TravelAgency.Controllers
{
    public class HomeController : Controller
    {

        static Model1 model = new Model1();
        // GET: Home
        public ActionResult Index()

        {
             /*           Voyage vo= new Voyage("China", 30);

                        model.Voyages.Add(vo);
                        model.SaveChanges();

            Voyage voo = new Voyage("Turkey", 7);
            model.Voyages.Add(voo);
            model.SaveChanges(); 

            Voyage vi = new Voyage("Argentina", 12);
            model.Voyages.Add(vi);
            model.SaveChanges();

            Voyage va = new Voyage("Nepal", 15);
            model.Voyages.Add(va);
            model.SaveChanges(); 

            Voyage vii = new Voyage("Australia", 30);
            model.Voyages.Add(vii);
            model.SaveChanges();

            Voyage vaa = new Voyage("Vietnam", 8);
            model.Voyages.Add(vaa);
            model.SaveChanges(); */

            return View();
        }

        [Authorize]
        public ActionResult GetPackages(Voyage v)
        {
         
            return View("Packages");
        }
        [Authorize]
        public ActionResult Packages()
        {
            ViewBag.voyages = model.Voyages.ToList();
            return View("Packages");
        }
/*        [HttpPost]
        public ActionResult Packages(Voyage v)
        {
            ViewBag.voygages = model.Voyages.ToList();
            return View("Packages", v);
     
        }*/

     
        public ActionResult List()
        {
            ViewBag.voygages = model.Voyages.ToList();
            return View();
        }

        public ActionResult Forum()
        {
            return View("Forum");
        }

        public ActionResult Testimonies()
        {
            return View("Testimonies");
        }

        public ActionResult Gallery()
        {
            return View("Gallery");
        }
        public ActionResult FAQ()
        {
            return View("FAQ");
        }
        public ActionResult Contact()
        {
            return View("Contact");
        }
    }
}