using _06_11_2024.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _06_11_2024.Pages
{
	public class EditModel(ApplicationContext context) : PageModel
	{
		private ApplicationContext context = context;
		public Film film;

		public void OnGet(int id)
		{
			if (id != 0)
				film = context.Films.First(f => f.Id == id);
			else
			{
				film = new()
				{
					Name = "",
					Director = "",
					Description = "",
					Jenre = "",
					Sessions = []
				};
			}
		}
		public IActionResult OnPost(int id, string name, string director, string description, string jenre)
		{
			if (id != 0)
				film = context.Films.First(f => f.Id == id);
			else
				film = new()
				{
					Sessions = []
				};

			film.Name = name;
			film.Director = director;
			film.Description = description;
			film.Jenre = jenre;

			if (id != 0)
				context.SaveChanges();
			else
			{
				context.Films.Add(film);
				context.SaveChanges();
			}
			return RedirectToPage("Index");
		}
	}
}
