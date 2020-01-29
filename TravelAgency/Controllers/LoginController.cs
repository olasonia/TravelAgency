using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TravelAgency.Models;
namespace TravelAgency.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Connect()
        {
            var Authentifie = HttpContext.User.Identity.IsAuthenticated;
            ViewData["Authentifie"] = Authentifie;
            User user = null;
            if (Authentifie)
            {
                using (var db = new Model1())
                {
                    user = (from p in db.Users
                                where p.Login == HttpContext.User.Identity.Name
                                select p).FirstOrDefault();
                }
            }
            return View(user);
        }
        [HttpPost]
        public ActionResult Connect(User user, string returnUrl)
        {
            User perso = null;
            var Authentifie = HttpContext.User.Identity.IsAuthenticated;
            ViewData["Authentifie"] = Authentifie;
            if (ModelState.IsValid)
            {
                using (var db = new Model1())
                {
                    perso = (from p in db.Users
                             where p.Login.Equals(user.Login) && p.Password.Equals(user.Password)
                             select p).FirstOrDefault();
                    if (perso != null)
                    {
                        FormsAuthentication.SetAuthCookie(perso.Login.ToString(), false);
                        Authentifie = true;
                        //if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
                        return Redirect("/Home/Packages");
                    }
                }
            }
            return View(user);
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                using (var db = new Model1())
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                }
                FormsAuthentication.SetAuthCookie(user.Login.ToString(), true);
                return Redirect("/Home/Packages");
            }
            return View(user);
        }



        public ActionResult Deconnexion()
        {
            FormsAuthentication.SignOut();
            return Redirect("/");
        }
    }
}