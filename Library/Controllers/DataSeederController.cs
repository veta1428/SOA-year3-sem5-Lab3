using Library.DataSeeding;
using Library.EF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class DataSeederController : ControllerBase
    {
        private readonly LibraryContext _libraryContext;

        public DataSeederController(LibraryContext libraryContext)
        {
            _libraryContext = libraryContext;
        }

        [HttpPost]
        [Route("seed-data")]
        public async Task SeedData(CancellationToken cancellationToken)
        {
            DataSeeder ds = new DataSeeder(_libraryContext);
            await ds.SeedData(cancellationToken);
        }
    }
}
