using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebMvcMovie.Models;
using Microsoft.Extensions.Configuration;

namespace WebMvcMovie.Controllers
{
    public class HomeController : Controller
    {
        public IConfiguration Configuration { get; set; }

        public HomeController(IConfiguration config)
        {
            Configuration = config;
        }

        public IActionResult Index()
        {
            //throw new Exception("That is some exception, Ooops!"); 

            // Accessing settingS from MY USER SECRETS.
            ViewData["myAppSetting"] = Configuration["myAppSetting"];
            ViewData["myConnectionString"] = Configuration.GetConnectionString("myConnectionString");

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
