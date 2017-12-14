using mvcdemo.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web;
using System.Web.Http;

namespace mvcdemo.Controllers
{
    public class SalesController : ApiController
    {

        public  IEnumerable<Sale>  GetSales()
        {
            InventoryContext ctx = new InventoryContext();
            return ctx.Sales;
        }

        public IEnumerable<Sale> GetSalesByProduct(int id)
        {
            InventoryContext ctx = new InventoryContext();
            return ctx.Sales.Where(prod => prod.Prodid == id);
        }

        [HttpPost]
        public void  PostSale(Sale sale) 
        {
            try
            {
                InventoryContext ctx = new InventoryContext();
                ctx.Sales.Add(sale);
                ctx.SaveChanges();
                // Thread.Sleep(10000);
            }
            catch(Exception ex)
            {
                HttpResponseMessage msg = new HttpResponseMessage();
                msg.StatusCode = HttpStatusCode.InternalServerError;
                msg.ReasonPhrase = "Error while adding sale -> " + ex.Message;
                // Write to trace 
                HttpContext.Current.Trace.Write("Error : " + ex);
                throw new HttpResponseException(msg);
            }

        }

    }
}
