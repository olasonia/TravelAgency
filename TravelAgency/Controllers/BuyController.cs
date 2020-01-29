using TravelAgency.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TravelAgency.Controllers
{
    public class BuyController : Controller
    {
        static Model1 model = new Model1();
        public ActionResult Index()
        {
           
            return View();
        }
        public ActionResult GetAddBasket(Voyage v)
        {
            ViewBag.voyageAdded = Session["Basket"];
            return View("Basket");
        }
        [HttpPost]
        public ActionResult AddBasket(int id)
        {

            ViewBag.id =id ;
            Voyage voyageAdded=model.Voyages.Find(id);
                   
                            if (Session["Basket"] == null)
                            {
                                Session["Basket"] = new List<Voyage>();                               
                            }
            var voyages = (List<Voyage>)Session["Basket"];
            voyages.Add(voyageAdded);
            Session["Basket"] = voyages;
            ViewBag.List = Session["Basket"];
            return View("Basket");
        
            
        }
        public ActionResult Basket()
        {
            ViewBag.voyageAdded = Session["Basket"];
            return View();
        }
        public ActionResult GetRemoveBasket(Voyage v)
        {
            return View("Remove");
        }
        public ActionResult RemoveBasket(Voyage v)
        {

            if (model.Voyages.Find(v.Id) != null)
            {
                model.Voyages.Remove(model.Voyages.Find(v.Id));
                model.SaveChanges();
                return View("Basket");
            }
            return View("Remove");
        }
    }
}


   