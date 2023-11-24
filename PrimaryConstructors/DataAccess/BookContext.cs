using Microsoft.EntityFrameworkCore;

namespace PrimaryConstructors.DataAccess
{
    public class BookContext(DbContextOptions<BookContext> options) : DbContext(options)
    {
        public DbSet<Book> Books { get; set; }
    }
}
