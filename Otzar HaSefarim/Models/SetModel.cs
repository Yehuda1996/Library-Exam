using System.ComponentModel.DataAnnotations;

namespace Otzar_HaSefarim.Models
{
	public class SetModel
	{
		public long Id { get; set; }
		[Required]
		public required string Title { get; set; }
		public long ShelfId { get; set; }
		public ShelfModel Shelf { get; set; }
		public List<BookModel> Books { get; set; } = [];
	}
}