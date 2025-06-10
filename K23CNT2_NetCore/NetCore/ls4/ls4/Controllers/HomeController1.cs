using Humanizer;
using Microsoft.AspNetCore.Mvc;
using ls4.Models;

namespace nvklesson04.Controllers
{
    public class NvkBookController : Controller
    {
        protected Book book = new Book();
        public IActionResult TvcIndex()
        {
            ViewBag.authors = book.Authors;
            ViewBag.genres = book.Genres;

            var books = book.GetBookList();
            return View(books);
        }
    }
}