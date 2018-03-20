using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class LibraryContext : BaseContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options):base(options)
        {
        }
        public virtual DbSet<User> Users { get; set; }
    }
}
