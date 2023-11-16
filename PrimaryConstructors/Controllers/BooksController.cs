using Microsoft.AspNetCore.Mvc;
using PrimaryConstructors.DataAccess;

namespace PrimaryConstructors.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly ILogger _logger;

        public BooksController(ILogger<BooksController> logger, IBookRepository bookRepository)
        {
            _logger = logger;
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Book>> Get() 
        {
            _logger.LogInformation("Get called on BooksController");

            return Ok(_bookRepository.Books);
        }

        [HttpPut("{id:int}")]
        public ActionResult<Book> Put(int id, [FromBody] Book book)
        {
            _logger.LogInformation("Put called on BooksController");

            var oldBook = _bookRepository.Books.SingleOrDefault(x => x.Id == id);

            if (oldBook == null)
                return NotFound();

            oldBook.Title = book.Title;
            oldBook.Year = book.Year;

            _bookRepository.SaveChanges();

            return Ok(book);
        }
    }
}
