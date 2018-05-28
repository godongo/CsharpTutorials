using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebMvcMovie.Models;

namespace WebMvcMovie.Controllers
{
    
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //throw new Exception("That is some exception, Ooops!"); 

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Test()
        {
            return View(new CheckboxModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Test(CheckboxModel model)
        {
            return View("Index");
        }

        public IActionResult IndexOption(int id)
        {
            var model = new CountryViewModel();
            model.Country = "CA";
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(CountryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var msg = model.Country + " selected";
                return RedirectToAction("IndexSuccess", new { message = msg });
            }

            // If we got this far, something failed; redisplay form.
            return View(model);
        }        
    }
}
