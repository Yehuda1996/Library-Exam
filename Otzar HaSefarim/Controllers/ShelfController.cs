using Microsoft.AspNetCore.Mvc;
using Otzar_HaSefarim.Service;
using Otzar_HaSefarim.ViewModel;

namespace Otzar_HaSefarim.Controllers
{
    public class ShelfController : Controller
    {
        private readonly IShelfService _shelfService;

        public ShelfController(IShelfService shelfService)
        {
            _shelfService = shelfService;
        }


        public IActionResult Index(long id)
        {
           ViewBag.LibraryId = id;
           return View(_shelfService.GetAllShelvesById(id));
        }

        public IActionResult Create(long LibraryId)
        {
            ViewBag.libraryId = LibraryId;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ShelfVM shelfVM, long LibraryId)
        {
            if (shelfVM == null)
            {
                return View("Index");
            }
            _shelfService.CreateShelf(shelfVM, LibraryId);
            return RedirectToAction("Index", new {id = LibraryId});
        }
    }
}
