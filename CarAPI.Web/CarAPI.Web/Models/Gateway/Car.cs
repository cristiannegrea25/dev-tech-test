using System.ComponentModel.DataAnnotations;

namespace CarAPI.Web.Models.Gateway
{
	public class Car
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(256)]
		public string Make { get; set; }

		[Required]
		[MaxLength(256)]
		public string Model { get; set; }

		public string Colour { get; set; }

		[Required]
		public int Year { get; set; }
	}
}
