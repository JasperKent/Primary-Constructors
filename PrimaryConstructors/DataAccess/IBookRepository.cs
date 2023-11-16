
namespace PrimaryConstructors.DataAccess
{
    public interface IBookRepository
    {
        IQueryable<Book> Books { get; }

        void SaveChanges();
    }
}