namespace _06_11_2024.Models
{
	public class Film
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Director { get; set; }
		public string Jenre { get; set; }
		public string Description { get; set; }
		public List<Session> Sessions { get; set; }
	}
}
