using Microsoft.EntityFrameworkCore;
using PhoneLibrary.Models;

namespace PhoneBackend.Data
{
    public class ApplicationContextDb : DbContext
    {
        public ApplicationContextDb(DbContextOptions<ApplicationContextDb> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; } = default;
    }
}
