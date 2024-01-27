using Microsoft.EntityFrameworkCore;
using ToDoList.Database;
using ToDoList.Infrastructure;

namespace ToDoList
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddAuthorization();
			builder.Services.AddControllers();

			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();
			builder.Services.AddDbContext<ToDoListContext>(option =>
				option.UseNpgsql(
					builder.Configuration.GetConnectionString("DefaultConnection")));
			builder.Services.AddSingleton<IDbProvider, DbProvider>();

			builder.Services.AddHostedService<DbInit>();

			var app = builder.Build();

			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseAuthorization();
			app.MapControllers();

			app.Run();
		}
	}
}
