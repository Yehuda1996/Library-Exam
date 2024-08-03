using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Otzar_HaSefarim.Data;
using Otzar_HaSefarim.Models;
using Otzar_HaSefarim.ViewModel;

namespace Otzar_HaSefarim.Service
{
	public class LibraryService : ILibraryService
	{
		private readonly ApplicationDbContext _context;

		public LibraryService(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<List<LibraryModel>> GetAllLibraries() =>
			await _context.Library
			.ToListAsync();

		public void AddGenre(LibraryVM libraryVM)
		{
			if (libraryVM != null)
			{
				LibraryModel newLibrary = new()
				{ Genre = libraryVM.Genre };
				_context.Library.Add(newLibrary);
				_context.SaveChanges();
			}
		}

        public LibraryModel? GetLibraryShelves(long Id) =>
			_context.Library
			.Include(x => x.Shelves)
			.FirstOrDefault(x => x.Id == Id);
        
    }
}
