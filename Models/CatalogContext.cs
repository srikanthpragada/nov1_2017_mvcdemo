using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web;

namespace mvcdemo.Models
{
    public class CatalogContext : DataContext 
    {
        public CatalogContext() :
              base(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=msdb;Integrated Security=True")
        {

        }

        public Table<Product>  Products
        {
            get
            {
                return GetTable<Product>();
            }
        }
    }
}