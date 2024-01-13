using Microsoft.EntityFrameworkCore;
using ToDoList.Database;

namespace ToDoList
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddAuthorization();

			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
			builder.Services.AddDbContext<ToDoListContext>(option =>
				option.UseNpgsql(
					builder.Configuration.GetConnectionString("DefaultConnection")));

			var app = builder.Build();

			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseAuthorization();

			app.MapGet("/", (ToDoListContext context) => context.ToDos.ToList());

			app.Run();
		}
	}
}
