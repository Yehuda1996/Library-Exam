using Otzar_HaSefarim.Data;
using Otzar_HaSefarim.Models;
using Otzar_HaSefarim.ViewModel;

namespace Otzar_HaSefarim.Service
{
    public class SetService : ISetService
    {
        private readonly ApplicationDbContext _context;

        public SetService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreateSet(SetVM setfVM, long shelfId)
        {
            if (setfVM != null)
            {
                SetModel newSet = new()
                {
                    Title = setfVM.Title,
                    ShelfId = shelfId
                };
                _context.Sets.Add(newSet);
                _context.SaveChanges();
            }
        }
        public List<SetModel> GetAllSetsById(long Id) =>
             _context.Sets.Where(x => x.ShelfId == Id).ToList();
    }
}
