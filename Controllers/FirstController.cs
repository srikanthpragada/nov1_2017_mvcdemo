using mvcdemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcdemo.Controllers
{
    public class FirstController : Controller
    {
        // GET: First
        public ActionResult Index()
        {
            int hour = DateTime.Now.Hour;

            if (hour < 12)
                ViewBag.Message = "Good Morning!";
            else
               if (hour < 17)
                 ViewBag.Message = "Good Afternoon";
               else
                  ViewBag.Message = "Good Evening";

            ViewBag.Title = "Index";

            return View();
        }

        public ActionResult About()
        {
            Information info = new Information { Topic = "Asp.Net MVC", Author = "Srikanth Pragada" };
            ViewBag.Title = "About";
            return View(info);
        }

        
    }
}