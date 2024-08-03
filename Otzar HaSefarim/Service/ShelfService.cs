using Microsoft.EntityFrameworkCore;
using Otzar_HaSefarim.Data;
using Otzar_HaSefarim.Models;
using Otzar_HaSefarim.ViewModel;

namespace Otzar_HaSefarim.Service
{
    public class ShelfService : IShelfService
    {
        private readonly ApplicationDbContext _context;

        public ShelfService(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<ShelfModel> GetAllShelvesById(long Id) =>
             _context.Shelves.Where(x => x.LibraryId == Id).ToList();

        public void CreateShelf(ShelfVM shelfVM, long LibraryId)
        {
            if (shelfVM != null)
            {
                ShelfModel newShelf = new()
                {
                    Height = shelfVM.Height,
                    Width = shelfVM.Width,
                    LibraryId = LibraryId
                };
                _context.Shelves.Add(newShelf);
                _context.SaveChanges();
            }
        }

    }
}
