using Microsoft.EntityFrameworkCore;
using ToDoList.Database.Models;

namespace ToDoList.Database
{
	public class ToDoListContext : DbContext
	{
		public DbSet<ToDo> ToDos { get; set; } = null!;
		public ToDoListContext(DbContextOptions<ToDoListContext> options)
			: base(options)
		{
			Database.EnsureDeleted();
			Database.EnsureCreated();   // создаем базу данных при первом обращении
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ToDo>().HasData(
					new ToDo(1, "1", "1223"),
					new ToDo(2, "2", "123"),
					new ToDo(3, "232", "23323")
			);
		}
	}
}
