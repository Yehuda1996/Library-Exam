using Microsoft.EntityFrameworkCore;
using Otzar_HaSefarim.Models;
using System.Collections.Immutable;

namespace Otzar_HaSefarim.Data
{
	public class ApplicationDbContext : DbContext
	{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
			Seed();
        }

		public void Seed()
		{
			if (!Library.Any())
			{
				IEnumerable<LibraryModel> newLibrary = [new()
				{
				Genre = "Torah",
				Shelves = [new(){
					Height = 60,
					Width = 100,
					Sets = [new(){
						Title = "Chumash",
						Books = [new(){
							Name = "Bereishit",
							Genre = "Torah",
							Height = 40,
							Width = 20
						}]
					}]
				}]
				}];
				Library.AddRange(newLibrary);
				SaveChanges();
			}
		}

        public DbSet<LibraryModel> Library { get; set; }
        public DbSet<ShelfModel> Shelves { get; set; }
        public DbSet<SetModel> Sets { get; set; }
        public DbSet<BookModel> Books { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
            modelBuilder.Entity<LibraryModel>()
                .HasMany(l => l.Shelves)
                .WithOne(s => s.Library)
                .HasForeignKey(i => i.LibraryId)
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<ShelfModel>()
				.HasMany(l => l.Sets)
				.WithOne(s => s.Shelf)
				.HasForeignKey(i => i.ShelfId)
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<SetModel>()
				.HasMany(l => l.Books)
				.WithOne(s => s.Set)
				.HasForeignKey(i => i.SetId)
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
