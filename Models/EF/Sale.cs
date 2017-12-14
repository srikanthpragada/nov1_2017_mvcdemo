using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvcdemo.Models.EF
{
    public class Sale
    {
        [Key]
        public int Invno { get; set; }
        public int Qty { get; set; }
        public int Prodid { get; set; }
        public decimal Amount { get; set; }
        public DateTime Transdate { get; set; }


    }
}