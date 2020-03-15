using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVClogin.Models;
namespace MVClogin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login lg)
        {
            if (ModelState.IsValid) {
                using (StudentsEntities se = new StudentsEntities()) {
             var log = se.students.Where(a=>a.Username.Equals(lg.username) && a.Password.Equals(lg.password)).FirstOrDefault();
                if (log != null)
                    {
                   Session["username"] = log.Username;
               return RedirectToAction("StudentHome", "Home");
                    }
               else {
                        lg.Err = true;
                         return RedirectToAction("DoSomething", "Home");
             
                    }
                }
            }
            return View();
        }
        public ActionResult StudentHome() {
            return View();
        }
        public ActionResult DoSomething()
        {
            //Your condition where you want to show your message
            //Add to the model state, your custom error 
            ModelState.AddModelError(string.Empty, "Username or Password undefiend");
        return View("login");
        }
        public ActionResult Logout() {
            Session.Clear();

            return RedirectToAction("login","Home"); }

    }
}