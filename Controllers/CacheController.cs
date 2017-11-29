using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcdemo.Controllers
{
    public class CacheController : Controller
    {
        [OutputCache(Duration=60)] 
        public ActionResult Index()
        {
            ViewBag.Message = DateTime.Now.ToString();
            return View();
        }
    }
}