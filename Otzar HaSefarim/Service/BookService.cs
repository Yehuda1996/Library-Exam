using Microsoft.EntityFrameworkCore;
using Otzar_HaSefarim.Data;
using Otzar_HaSefarim.Models;
using Otzar_HaSefarim.ViewModel;

namespace Otzar_HaSefarim.Service
{
    public class BookService : IBookService
    {
        private readonly ApplicationDbContext _context;

        public BookService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddBook(BookVM bookVM, long setId)
        {
            if (bookVM != null)
            {
                var mySet = _context.Sets.FirstOrDefault(x => x.Id == setId);
                var myShelf = _context.Shelves.FirstOrDefault(x => x.Id == mySet.ShelfId);
                var height = myShelf.Height;

                var allSetSize = _context.Shelves
                    .Where(x => x.Id == myShelf.Id)
                    .Include(x => x.Sets)
                    .ThenInclude(x => x.Books)
                    .SelectMany(x => x.Sets
                    .SelectMany(x => x.Books
                    .Where(x => x.SetId == setId)
                    .Select(x => x.Width)
                         )
                     ).Sum();

                if (bookVM.Height <= height && myShelf.Width >= allSetSize + bookVM.Width)
                {
                    BookModel newBook = new()
                    {
                        Name = bookVM.Name,
                        Genre = bookVM.Genre,
                        Height = bookVM.Height,
                        Width = bookVM.Width,
                        SetId = setId
                    };
                    _context.Books.Add(newBook);
                    _context.SaveChanges();
                }
                else
                {
                    var res = new Exception("Does not fit in shelf!!!");
                }
            }
        }

        public List<BookModel> GetAllBooksById(long Id) =>
             _context.Books.Where(x => x.SetId == Id).ToList();
    }
}
