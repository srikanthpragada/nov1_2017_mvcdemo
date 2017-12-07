using mvcdemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace mvcdemo.Controllers
{
    public class UserController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Login()
        {
            User u = new User();
            return View(u);
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                if (user.Username == "admin" && user.Password == "admin")
                {
                    FormsAuthentication.SetAuthCookie(user.Username, false);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Message = "Sorry! Invalid Login!";
                    return View();
                }
            }
            else
                return View();
        }
    }
}