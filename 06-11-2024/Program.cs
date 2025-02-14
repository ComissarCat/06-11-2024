using Microsoft.EntityFrameworkCore;

namespace _06_11_2024
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			string connection = builder.Configuration.GetConnectionString("DefaultConnection");

			// добавляем контекст ApplicationContext в качестве сервиса в приложение
			builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlite(connection));

			// Add services to the container.
			builder.Services.AddRazorPages();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapRazorPages();

			app.Run();
		}
	}
}
