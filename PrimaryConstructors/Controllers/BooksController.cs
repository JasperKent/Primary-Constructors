using Microsoft.AspNetCore.Mvc;
using PrimaryConstructors.DataAccess;

namespace PrimaryConstructors.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController
        (
            ILogger<BooksController> logger, 
            IBookRepository bookRepository
        ) 
        : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Book>> Get() 
        {
            logger.LogInformation("Get called on BooksController");

            return Ok(bookRepository.Books);
        }

        [HttpPut("{id:int}")]
        public ActionResult<Book> Put(int id, [FromBody] Book book)
        {
            logger.LogInformation("Put called on BooksController");

            var oldBook = bookRepository.Books.SingleOrDefault(x => x.Id == id);

            if (oldBook == null)
                return NotFound();

            oldBook.Title = book.Title;
            oldBook.Year = book.Year;

            bookRepository.SaveChanges();

            return Ok(book);
        }
    }
}
