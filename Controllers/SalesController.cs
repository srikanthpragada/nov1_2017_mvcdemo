using mvcdemo.Models.EF;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
        [HttpGet]
        public  IEnumerable<Sale>  GetSales()
        {
            InventoryContext ctx = new InventoryContext();
            return ctx.Sales;
        }
        [HttpGet]
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

        [HttpDelete]
        public void deleteSale(int id)
        {
            try
            {
                InventoryContext ctx = new InventoryContext();
                var sale = ctx.Sales.Find(id);
                if (sale != null)
                {
                    ctx.Sales.Remove(sale);
                    ctx.SaveChanges();
                }
                else
                {
                    HttpResponseMessage msg = new HttpResponseMessage();
                    msg.StatusCode = HttpStatusCode.NotFound;
                    msg.ReasonPhrase = "Invoice No. is not found";
                    throw new HttpResponseException(msg);
                }
            }
            catch (SqlException ex)
            {
                HttpResponseMessage msg = new HttpResponseMessage();
                msg.StatusCode = HttpStatusCode.InternalServerError;
                msg.ReasonPhrase = "Error while adding sale -> " + ex.Message;
                // Write to trace 
                HttpContext.Current.Trace.Write("Error : " + ex);
                throw new HttpResponseException(msg);
            }

        }


        [HttpPut]
        public void updateSale(int id,Sale newSale)
        {
            try
            {
                InventoryContext ctx = new InventoryContext();
                var sale = ctx.Sales.Find(id);
                if (sale != null)
                {
                    sale.Amount = newSale.Amount;
                    sale.Qty = newSale.Qty; 
                    ctx.SaveChanges();
                }
                else
                {
                    HttpResponseMessage msg = new HttpResponseMessage();
                    msg.StatusCode = HttpStatusCode.NotFound;
                    msg.ReasonPhrase = "Invoice No. is not found";
                    throw new HttpResponseException(msg);
                }
            }
            catch (SqlException ex)
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
