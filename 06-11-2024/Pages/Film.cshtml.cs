using _06_11_2024.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace _06_11_2024.Pages
{
	public class FilmModel(ApplicationContext context) : PageModel
	{
		private ApplicationContext context = context;
		public Film film;

		public void OnGet(int id)
		{
			film = context.Films.Include(f => f.Sessions).First(f => f.Id == id);
		}

		public IActionResult OnGetDelete(int id)
		{
			film = context.Films.Include(f => f.Sessions).First(f => f.Id == id);
			context.Films.Remove(film);
			context.SaveChanges();
			return RedirectToPage("Index");
		}

		public IActionResult OnPostAddSession(int id, DateOnly date)
		{
			Session session = new() { Date = date };
			context.Sessions.Add(session);
			film = context.Films.Include(f => f.Sessions).First(f => f.Id == id);
			film.Sessions ??= [];
			film.Sessions.Add(session);
			context.SaveChanges();
			return RedirectToPage("Film", new { id });
		}
	}
}
