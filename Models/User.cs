using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvcdemo.Models
{
    public class User
    {
        [StringLength(10,MinimumLength =3,ErrorMessage = "Username must be 3 to 10 chars")]
        [Required(ErrorMessage = "Username is required!")]
        public String Username { get; set; }

        [StringLength(8, MinimumLength = 3, ErrorMessage = "Password must be 3 to 8 chars")]
        [Required(ErrorMessage = "Password is required!")]
        public String Password { get; set; }
    }
}