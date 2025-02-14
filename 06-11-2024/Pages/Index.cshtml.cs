using _06_11_2024.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace _06_11_2024.Pages
{
	public class IndexModel(ApplicationContext context) : PageModel
	{
		private ApplicationContext context = context;
		public List<Film> films;
		public bool fullList;

		public void OnGet(string? search)
		{
			films = [.. context.Films.Include(f => f.Sessions)];
			if (search is not null)
			{
				search = search.ToLower();
				films = films.Where(f => f.Name.ToLower().Contains(search)
				|| f.Jenre.ToLower().Contains(search)
				|| f.Director.ToLower().Contains(search)
				|| f.Description.ToLower().Contains(search)).ToList();
				fullList = false;
			}
			else
				fullList = true;
		}
	}
}
