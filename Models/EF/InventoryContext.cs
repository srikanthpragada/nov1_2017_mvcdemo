using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace mvcdemo.Models.EF
{
    public class InventoryContext : DbContext 
    {
        public InventoryContext() : base("name=localdb")
        {
            Database.SetInitializer<InventoryContext>(null);
        }

        public DbSet<Product>  Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}