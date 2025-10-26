using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KonditoriPallasSite.Models
{
	public class Product
	{
		public int Id { get; set; }

		[Required, StringLength(100)]
		public string Name { get; set; } = string.Empty; // ← standardvärde

		[StringLength(500)]
		public string? Description { get; set; }         // ← gör nullable om frivillig

		[Column(TypeName = "decimal(8,2)")]
		public decimal Price { get; set; }

		public int CategoryId { get; set; }
		public Category? Category { get; set; }          // ← gör nullable
	}

}

