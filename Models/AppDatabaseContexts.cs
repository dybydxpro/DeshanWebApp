using Microsoft.EntityFrameworkCore;

namespace DeshanWebApp.Models
{
    public class AppDatabaseContexts:DbContext
    {        
        public AppDatabaseContexts(DbContextOptions<AppDatabaseContexts> options) : base(options)
        {

        }

        public DbSet<Asset> Assets { get; set; }
        public DbSet<Cart> Carts { get; set; }
    }
}
