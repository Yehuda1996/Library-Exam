using Otzar_HaSefarim.Models;
using Otzar_HaSefarim.ViewModel;

namespace Otzar_HaSefarim.Service
{
	public interface ILibraryService
	{
		public Task<List<LibraryModel>> GetAllLibraries();

		public void AddGenre(LibraryVM libraryVM);

		public LibraryModel? GetLibraryShelves(long Id);
	}
}
