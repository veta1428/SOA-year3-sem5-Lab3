using Library.DataSeeding;
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
    public class LibraryController : ControllerBase
    {
        private readonly LibraryContext _libraryContext;
        public LibraryController(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }

        [HttpGet(Name = "GetLibraries")]
        [Route("get-libraries")]
        public async Task<IEnumerable<LibraryModel>> GetLibraries(CancellationToken cancellationToken)
        {
            return await _libraryContext.Libraries
                .Select(l => new LibraryModel(l.Id, l.Name, l.Description, l.Address, l.Phone, l.Email))
                .ToListAsync(cancellationToken);
        }
    }
}
