using Otzar_HaSefarim.Models;
using Otzar_HaSefarim.ViewModel;

namespace Otzar_HaSefarim.Service
{
    public interface IBookService
    {
        public List<BookModel> GetAllBooksById(long Id);

        public void AddBook(BookVM bookVM, long setId);

    }
}
