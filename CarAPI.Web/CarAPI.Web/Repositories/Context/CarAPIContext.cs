using CarAPI.Web.Models.Gateway;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CarAPI.Web.Repositories.Context
{
	public class CarAPIContext : DbContext
	{
		public DbSet<Car> Cars { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite("Filename=CarAPIDatabase.db", options =>
			{
				options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
			});

			base.OnConfiguring(optionsBuilder);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// Map table names
			modelBuilder.Entity<Car>().ToTable("Blogs", "test");
			modelBuilder.Entity<Car>(entity =>
			{
				entity.HasKey(e => e.Id);
			});

			base.OnModelCreating(modelBuilder);
		}
	}
}
