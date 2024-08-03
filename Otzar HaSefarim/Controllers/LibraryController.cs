using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Otzar_HaSefarim.Data;
using Otzar_HaSefarim.Models;
using Otzar_HaSefarim.Service;
using Otzar_HaSefarim.ViewModel;
namespace Otzar_HaSefarim.Controllers
{
	public class LibraryController : Controller
	{
		private readonly ILibraryService _libraryService;

        public LibraryController(ILibraryService libraryService)
        {
            _libraryService  = libraryService;
        }

		public async Task<IActionResult> Index() =>
			View(await _libraryService.GetAllLibraries());

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(LibraryVM libraryVM)
		{
			if (libraryVM == null)
			{
				return View("Index");
			}
			_libraryService.AddGenre(libraryVM);
			return RedirectToAction("Index");
		}

        public IActionResult Shelves(long Id)
        {
			var shelvesLibrary = _libraryService.GetLibraryShelves(Id);
			return View(shelvesLibrary);
        }
    }
}
