using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KonditoriPallasSite.Models
{
	public class Product
	{
		public int Id { get; set; }

		[Required, StringLength(100)]
		public required string Name { get; set; }

		[StringLength(500)]
		public string? Description { get; set; }

		[Column(TypeName = "decimal(8,2)")]
		public decimal Price { get; set; }

		public int CategoryId { get; set; }
		public required Category Category { get; set; }
	}
}

