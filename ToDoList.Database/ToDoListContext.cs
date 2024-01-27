using Microsoft.EntityFrameworkCore;
using System.Web.Helpers;
using ToDoList.Database.Models;

namespace ToDoList.Database
{
	public class ToDoListContext(DbContextOptions<ToDoListContext> options) : DbContext(options)
	{
		public DbSet<ToDo> ToDos { get; set; }
		public DbSet<User> Users { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(User.GetConfiguration);
			modelBuilder.ApplyConfiguration(ToDo.GetConfiguration);
		}
	}
}
