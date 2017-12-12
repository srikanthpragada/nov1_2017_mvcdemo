using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcdemo.Models.EF
{
    public class Util
    {
        public static List<SelectListItem> CategoryItems
        {
            get
            {
                InventoryContext ctx = new InventoryContext();
                List<SelectListItem> items = new List<SelectListItem>();
                foreach(var cat in ctx.Categories)
                {
                    items.Add(new SelectListItem { Text = cat.CatDesc, Value = cat.CatCode });
                }

                return items;
            }
        }
    }
}