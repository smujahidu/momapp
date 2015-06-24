using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace ClientApp.Controllers
{
    public class MomController : Controller
    {
        //
        // GET: /Mom/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateDoc()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateDoc(FormCollection collection)
        {
            var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
            var message = new MailMessage();
            message.To.Add(new MailAddress("seemufassil@gmail.com"));  // replace with valid value 
            message.From = new MailAddress("mufassilsk@gmail.com");  // replace with valid value
            message.Subject = collection.Get("Subject");
            message.Body = collection.Get("Body");
            message.IsBodyHtml = true;

            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = "mufassilsk@gmail.com",  // replace with valid value
                    Password = "password"  // replace with valid value
                };
                smtp.Credentials = credential;
                smtp.Host = "smtp-mail.outlook.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.SendMailAsync(message);
                //return RedirectToAction("Sent");
                return View();
            }
        }
        public ActionResult History()
        {
            return View();
        }
    }
}
