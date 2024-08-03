using System.ComponentModel.DataAnnotations;

namespace Otzar_HaSefarim.Models
{
	public class ShelfModel
	{
		public long Id { get; set; }
		[Required]
		public required double Height { get; set; }
		[Required]
		public required double Width { get; set; }
		public long LibraryId { get; set; }
		public LibraryModel Library { get; set; }
		public List<SetModel> Sets { get; set; } = [];

	}
}
