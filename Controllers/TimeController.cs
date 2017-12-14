using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace mvcdemo.Controllers
{
    public class TimeController : ApiController
    {
        [HttpGet]
        public String  GetTime()
        {
            String result =  "{" + String.Format("Hours: {0}, Mins : {1}, Secs : {2}", 
                    DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second) + "}";
            return result;
        }
    }
}
