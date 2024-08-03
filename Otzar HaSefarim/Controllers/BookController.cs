using Microsoft.AspNetCore.Mvc;
using Otzar_HaSefarim.Service;
using Otzar_HaSefarim.ViewModel;

namespace Otzar_HaSefarim.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }


        public IActionResult Index(long id)
        {
            ViewBag.SetId = id;
            return View(_bookService.GetAllBooksById(id));
        }

        public IActionResult Create(long SetId)
        {
            ViewBag.SetId = SetId;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BookVM bookVM, long SetId)
        {
            if (bookVM == null)
            {
                return View("Index");
            }
            _bookService.AddBook(bookVM, SetId);
            return RedirectToAction("Index", new { id = SetId });
        }
    }
}
