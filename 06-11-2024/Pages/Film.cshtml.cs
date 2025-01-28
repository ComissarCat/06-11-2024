using _06_11_2024.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace _06_11_2024.Pages
{
	public class FilmModel : PageModel
	{
		public Film film;
		public FilmModel()
		{
		}
		public void OnGet(int id)
		{
			string fileName = "films.json";
			string jsonString = System.IO.File.ReadAllText(fileName);
			List<Film> films = JsonSerializer.Deserialize<List<Film>>(jsonString);
			film = films.First(f => f.Id == id);
		}
	}
}
