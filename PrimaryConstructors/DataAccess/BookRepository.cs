namespace PrimaryConstructors.DataAccess
{
    public class BookRepository : IBookRepository
    {
        private readonly BookContext _context;

        public BookRepository(BookContext context)
        {
            _context = context;
        }

        public IQueryable<Book> Books => _context.Books;

        public void SaveChanges() => _context.SaveChanges();
    }
}
