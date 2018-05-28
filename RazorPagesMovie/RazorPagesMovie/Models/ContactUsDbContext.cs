using Microsoft.EntityFrameworkCore;

namespace RazorPagesMovie.Models
{
    public class ContactUsDbContext : DbContext
    {
        public ContactUsDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
