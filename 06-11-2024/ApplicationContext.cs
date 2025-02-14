using _06_11_2024.Models;
using Microsoft.EntityFrameworkCore;

namespace _06_11_2024
{
	public class ApplicationContext : DbContext
	{
		public DbSet<Film> Films { get; set; }
		public DbSet<Session> Sessions { get; set; }
		public ApplicationContext(DbContextOptions<ApplicationContext> options)
			: base(options)
		{
			Database.EnsureCreated();   // создаем базу данных при первом обращении
		}
	}
}
