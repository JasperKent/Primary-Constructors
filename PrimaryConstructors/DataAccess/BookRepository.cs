namespace PrimaryConstructors.DataAccess
{
    public class BookRepository(BookContext context) : IBookRepository
    {
        public IQueryable<Book> Books => context.Books;

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
