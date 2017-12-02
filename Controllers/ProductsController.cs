using mvcdemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcdemo.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Delete(int id)
        {
            // delete
            try
            {
                CatalogContext ctx = new CatalogContext();
                var prod = ctx.Products.Where(p => p.Id == id).SingleOrDefault();
                if (prod != null)
                {
                    ctx.Products.DeleteOnSubmit(prod);
                    ctx.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                TempData["message"] = "Sorry! Produdct cannot be deleted as it is associated with sales!";
            }
            return RedirectToAction("List");
        }

        public ActionResult Add()
        {
            Product model = new Product();
            return View(model);
        }
        [HttpPost]
        public ActionResult Add(Product prod)
        {
            try
            {
                CatalogContext ctx = new CatalogContext();
                ctx.Products.InsertOnSubmit(prod);
                ctx.SubmitChanges();
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error : " + ex.Message;
                return View(prod);
            }
        }


        public ActionResult Edit(int id)
        {
            // Get Product with the given id
            try
            {
                CatalogContext ctx = new CatalogContext();
                var prod = ctx.Products.Where(p => p.Id == id).SingleOrDefault();
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
                CatalogContext ctx = new CatalogContext();
                var prod = ctx.Products.Where(p => p.Id == id).SingleOrDefault();
                if (prod != null)
                {
                    prod.Name = newprod.Name;
                    prod.Price = newprod.Price;
                    prod.Qoh = newprod.Qoh;
                    prod.Category = newprod.Category;
                    prod.Remarks = newprod.Remarks;
                    ctx.SubmitChanges();
                    return RedirectToAction("List");
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
                return View(newprod);
            }

        }


        public ActionResult List()
        {
            CatalogContext ctx = new CatalogContext();
            return View(ctx.Products);
        }
    }
}