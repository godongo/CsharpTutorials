using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebMvcMovie.ViewModel;

namespace WebMvcMovie.Controllers
{
    public class DemoController : Controller
    {       
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MakesMarques()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MakesMarques(DemoViewModel model)
        {
            return View();
        }
        
        private void SendMail(string mailbody)
        {
            using (var message = new MailMessage("Contact.Email", "me@mydomain.com"))
            {
                message.To.Add(new MailAddress("me@mydomain.com"));
                message.From = new MailAddress("Contact.Email");
                message.Subject = "New E-Mail from my website";
                message.Body = mailbody;

                using (var smtpClient = new SmtpClient("mail.mydomain.com"))
                {
                    smtpClient.Send(message);
                }
            }
        }       
    }
}