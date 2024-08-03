using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Otzar_HaSefarim.Models
{
	[Index(nameof(Genre), IsUnique = true)]
	public class LibraryModel
	{
		public long Id { get; set; }
		[Required]
		public required string Genre { get; set; }
		public List<ShelfModel> Shelves { get; set; } = [];
	}
}
