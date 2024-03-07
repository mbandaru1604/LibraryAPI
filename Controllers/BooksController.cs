using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LibraryAPI.Models;
using LibraryAPI.Services;

namespace LibraryAPI.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        IBooksService _bookService;

        public BooksController(IBooksService bookService)
        {
            _bookService = bookService;
        }
        [HttpPost]
        [Route("libraries/{libraryid}")]
        public IActionResult AddBook([FromQuery] string libraryId, Books book)
        {
            var response = _bookService.AddBook(Convert.ToInt32(libraryId), book);
            return Ok(response);
        }
        [HttpGet]
        [Route("libraries/{libraryid}")]
        public IActionResult GetBooks([FromQuery]string libraryId)
        {
            var response= _bookService.GetBooks(Convert.ToInt32(libraryId));
            return Ok(response);
        }
    }
}
