using BookLibrary.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookLibrary.Controllers
{
    public class BooksApiController : Controller
    {
        private readonly BookApiService bookApiService;

        public BooksApiController(BookApiService bookApiService)
        {
            this.bookApiService = bookApiService;
        }

        public async Task<IActionResult> GetAllBooks()
        {
            var books = await bookApiService.GetBooks();
            return View(books);
        }
    }
}
