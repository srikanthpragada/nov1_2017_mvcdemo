using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcdemo.Models
{
    public class ProductsUtil
    {
         public static List<SelectListItem> Categories
        {

            get
            {
                var items = new List<SelectListItem>();

                CatalogContext ctx = new CatalogContext();

                foreach(Category cat in ctx.Categories)
                {
                    // Convert each Category object to SelectListItem object 
                    items.Add(new SelectListItem { Text = cat.Description, Value = cat.Code });
                }

                return items;
            }
        }
    }
}