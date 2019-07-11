namespace CarAPI.Web.Models.Domain
{
	public class CarViewModel
	{
		public CarViewModel()
		{
			Make = new CarMake();
		}

		public int Id { get; set; }
		public CarMake Make { get; set; }
		public string Colour { get; set; }
		public int Year { get; set; }
	}
}
