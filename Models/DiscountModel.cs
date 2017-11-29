using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvcdemo.Models
{
    public class DiscountModel
    {

        [Range(1000, Double.MaxValue, ErrorMessage = "Invalid value for Amount")]
        public double Amount { get; set; }

        [Range(0,50, ErrorMessage ="Discount rate must be between 0 and 50")]
        public double Rate { get; set; }

        public double Discount { get; set; }
    }
}