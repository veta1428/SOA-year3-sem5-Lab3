using Library.EF;
using Library.Types;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly LibraryContext _libraryContext;

        public BookController(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }

        [HttpGet]
        [Route("get-books/{libraryId}")]
        public async Task<IEnumerable<BookModel>> GetBooksByLibraryId([FromRoute] int libraryId, CancellationToken cancellationToken)
        {
            return await _libraryContext.Books.Where(b => b.Library.Id == libraryId).Select(b => new BookModel(b.Id, b.Title, b.Author, b.Genre, b.Pages)).ToListAsync(cancellationToken);
        }

        [HttpGet]
        [Route("get-book-pdf/{bookId}")]
        public async Task<IActionResult> GetBook([FromRoute] int bookId, CancellationToken cancellationToken)
        {
            var book = await _libraryContext.Books.Where(b => b.Id == bookId).FirstAsync();
            var content = await System.IO.File.ReadAllBytesAsync(@"Books/" + book.FilePath);
            return new FileContentResult(content, "application/pdf");
        }
    }
}
