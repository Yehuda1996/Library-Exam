using Otzar_HaSefarim.Models;
using Otzar_HaSefarim.ViewModel;

namespace Otzar_HaSefarim.Service
{
    public interface IShelfService
    {
        public List<ShelfModel> GetAllShelvesById(long Id);

        public void CreateShelf(ShelfVM shelfVM, long libraryId);
    }
}
