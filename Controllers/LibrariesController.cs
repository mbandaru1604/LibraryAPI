using LibraryAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/library")]
    [ApiController]
    public class LibrariesController : ControllerBase
    {
        ILibraryService _libraryService;

        public LibrariesController(ILibraryService libraryService)
        {
            _libraryService = libraryService;    
        }

        [HttpDelete]
        public IActionResult DeleteLibrary(int libraryId)
        {
            var response = _libraryService.DeleteLibrary(libraryId);
            return Ok(response);
        }
    }
}
