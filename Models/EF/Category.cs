﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvcdemo.Models.EF
{
    public class Category
    {
        [Key]
        public string CatCode { get; set; }
        public string CatDesc { get; set; }

    }
}