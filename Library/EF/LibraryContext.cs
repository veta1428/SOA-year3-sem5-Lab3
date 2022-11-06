using Library.EF.Entities;
using Microsoft.EntityFrameworkCore;
using CoreLibrary = Library.EF.Entities.Library;

namespace Library.EF
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions options): base(options)
        {
            Database.Migrate();
        }

        public DbSet<CoreLibrary> Libraries { get; set; } = null!;

        public DbSet<Book> Books { get; set; } = null!;
    }
}
