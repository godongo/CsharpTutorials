using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesMovie.Models;
using System.Threading.Tasks;

namespace RazorPagesMovie.Pages.ContactUs
{
    public class CreateModel : PageModel
    {
        private readonly ContactUsDbContext _db;

        public CreateModel(ContactUsDbContext db)
        {
            _db = db;
        }
        
        //  Opt-in to model binding
        [BindProperty]
        public Customer Customer { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.Customers.Add(Customer);
            await _db.SaveChangesAsync();
            return RedirectToPage("/ContactUs/Index");
        }
    }
}