using _06_11_2024.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace _06_11_2024.Pages
{
	public class IndexModel : PageModel
	{
		private readonly ILogger<IndexModel> _logger;
		public List<Film> films;
		public IndexModel(ILogger<IndexModel> logger)
		{
			_logger = logger;
		}

		public void OnGet()
		{
			string fileName = "films.json";
			string jsonString = System.IO.File.ReadAllText(fileName);
			films = JsonSerializer.Deserialize<List<Film>>(jsonString);
		}
	}
}
