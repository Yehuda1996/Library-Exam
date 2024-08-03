using Microsoft.AspNetCore.Mvc;
using Otzar_HaSefarim.Service;
using Otzar_HaSefarim.ViewModel;

namespace Otzar_HaSefarim.Controllers
{
    public class SetController : Controller
    {
        private readonly ISetService _setService;

        public SetController(ISetService setService)
        {
            _setService = setService;
        }


        public IActionResult Index(long id)
        {
            ViewBag.ShelfId = id;
            return View(_setService.GetAllSetsById(id));
        }

        public IActionResult Create(long ShelfId)
        {
            ViewBag.ShelfId = ShelfId;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SetVM setVM, long ShelfId)
        {
            if (setVM == null)
            {
                return View("Index");
            }
            _setService.CreateSet(setVM, ShelfId);
            return RedirectToAction("Index", new { id = ShelfId });
        }
    }
}
