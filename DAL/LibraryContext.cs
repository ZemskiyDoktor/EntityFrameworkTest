using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class LibraryContext : BaseContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options):base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
    }
}
