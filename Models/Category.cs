using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KonditoriPallasSite.Models
{
	public class Category
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[StringLength(50)]
		public string? Name { get; set; }              // kan vara null tills något anges

		public ICollection<Product>? Products { get; set; }   // lista kan saknas
	}
}

