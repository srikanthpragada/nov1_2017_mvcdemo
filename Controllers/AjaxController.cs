using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcdemo.Controllers
{
    public class AjaxController : Controller
    {
         
        public ActionResult Index()
        {
            return View();
        }

        public String Now()
        {
            return DateTime.Now.ToString();
        }

        public int Add(int first, int second)
        {
            return first + second;
        }

        public PartialViewResult Factors(int number)
        {
            var factors = new List<int>();

            for (int i = 2; i <= number / 2; i++)
                if (number % i == 0)
                    factors.Add(i);

            return PartialView("Factors", factors);

            
        }
    }
}