using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace mvcdemo.Controllers
{
    public class MailController : Controller
    {
        
        public ActionResult Send()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Send(string subject, string body)
        {
            try
            {
                MailMessage m = new MailMessage();
                m.To.Add(new MailAddress("scott@demo.com"));
                m.From = new MailAddress("anders@demo.com");
                m.Subject = subject;
                m.IsBodyHtml = true;
                m.Body = body;


                //add web.config as attachment

                Attachment a1 = new Attachment(Request.MapPath("~/web.config"));
                m.Attachments.Add(a1);

                SmtpClient smtp = new SmtpClient("localhost");
                // logon to server 
                smtp.UseDefaultCredentials = false;
                smtp.EnableSsl = false;
                smtp.Credentials = new System.Net.NetworkCredential("anders@demo.com", "aa");

                smtp.Send(m);
                ViewBag.Message = "Mail sent successfully!";
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error --> " + ex.Message;
            }
            return View();
        }
    }
}