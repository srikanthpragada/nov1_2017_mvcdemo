using mvcdemo.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcdemo.Controllers
{
    public class ItemsController : Controller
    {
       
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public PartialViewResult Index(string prodname)
        {
            InventoryContext ctx = new InventoryContext();
            var products = from prod in ctx.Products
                           where prod.Name.Contains(prodname)
                           select prod;

            return PartialView("Search", products);
        }


        public ActionResult List()
        {
            InventoryContext ctx = new InventoryContext();
            return View(ctx.Products.ToList<Product>());

        }

        public ActionResult Add()
        {
            Product model = new Product();
            return View(model);
        }
        [HttpPost]
        public ActionResult Add(Product prod)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    InventoryContext ctx = new InventoryContext();
                    ctx.Products.Add(prod);
                    ctx.SaveChanges();
                    return RedirectToAction("List");
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "Error : " + ex.Message;
                    return View(prod);
                }
            }
            else
                return View(prod);
        }


        public ActionResult Delete(int id)
        {
            // delete
            try
            {
                InventoryContext ctx = new InventoryContext();
                var prod = ctx.Products.Find(id);
                if (prod != null)
                {
                    ctx.Products.Remove(prod);
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                TempData["message"] = "Sorry! Produdct cannot be deleted as it is associated with sales!";
            }
            return RedirectToAction("List");
        }



        // Get
        public ActionResult Edit(int id)
        {
            // Get Product with the given id
            try
            {
                InventoryContext ctx = new InventoryContext();
                var prod = ctx.Products.Find(id);
                if (prod != null)
                {
                    return View(prod);
                }
                else
                {
                    ViewBag.Message = "Sorry! Produdct Id Not Found!";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error : " + ex.Message;
                return View();
            }

        }

        [HttpPost]
        public ActionResult Edit(int id, Product newprod)
        {
            // Get Product with the given id
            try
            {
                InventoryContext ctx = new InventoryContext();
                newprod.Id = id;
                ctx.Entry(newprod).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();
                return RedirectToAction("List");
                
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error : " + ex.Message;
                return View(newprod);
            }

        }

    }
}