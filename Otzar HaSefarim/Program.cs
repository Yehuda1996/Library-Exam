using Microsoft.EntityFrameworkCore;
using Otzar_HaSefarim.Data;
using Otzar_HaSefarim.Service;

namespace Otzar_HaSefarim
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();

			builder.Services.AddScoped<ILibraryService, LibraryService>();
			builder.Services.AddScoped<IShelfService, ShelfService>();
			builder.Services.AddScoped<ISetService, SetService>();
			builder.Services.AddScoped<IBookService, BookService>();
			

			builder.Services.AddDbContext<ApplicationDbContext>(options =>
				options.UseSqlServer(
				builder.Configuration.GetConnectionString("DefaultConnection")));

			var app = builder.Build();

			using (var scope = app.Services.CreateScope())
			{
				var services = scope.ServiceProvider;
				try
				{
					var context = services.GetRequiredService<ApplicationDbContext>();
					context.Database.EnsureCreated();
				}
				catch (Exception ex)
				{
					var logger = services.GetRequiredService<ILogger<Program>>();
					logger.LogError(ex, "An error occurred creating the DB.");
				}
			}

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}
