using Otzar_HaSefarim.Models;
using Otzar_HaSefarim.ViewModel;

namespace Otzar_HaSefarim.Service
{
    public interface ISetService
    {
        public List<SetModel> GetAllSetsById(long Id);

        public void CreateSet(SetVM setfVM, long shelfId);
    }
}
