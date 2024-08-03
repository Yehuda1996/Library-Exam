using System.ComponentModel.DataAnnotations;

namespace Otzar_HaSefarim.Models
{
	public class BookModel
	{
		public long Id { get; set; }
		[Required, StringLength(50)]
		public required string Name { get; set; }
		[Required]
		public required string Genre { get; set; }
		[Required]
		public required double Height { get; set; }
		[Required]
		public required double Width { get; set; }
		public long SetId { get; set; }
		public SetModel Set { get; set; }
	}
}