using mvcdemo.Models;
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

        [OutputCache(Duration = 60 , VaryByParam = "catcode" )]
        public ActionResult List(string catcode)
        {
            CatalogContext ctx = new CatalogContext();
            ViewBag.Message = "Last executed at : " + DateTime.Now.ToString();
            return View( ctx.Products.Where ( prod => prod.Category == catcode));
        }

        // Data caching demo
        public ActionResult Products(string catcode)
        {
            var products = HttpContext.Cache["products"];
            ViewBag.Message = "Cache Retrieved!";
            if ( products == null)
            {
                CatalogContext ctx = new CatalogContext();
                products = ctx.Products;
                HttpContext.Cache.Insert("products",products, null,
                            DateTime.Now.AddSeconds(60), TimeSpan.Zero);
                ViewBag.Message = "Cache Created";
            }

            
            return View("List",products);
        }
    }
}