using System;
using System.ComponentModel.DataAnnotations;

namespace KonditoriPallasSite.Models
{
	public class ContactMessage
	{
		public int Id { get; set; }

		[Required] public string? Name { get; set; }
		[Required, Phone] public string? Phone { get; set; }
		[Required, EmailAddress] public string? Email { get; set; }
		[Required] public string? Message { get; set; }

		public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;
	}
}

