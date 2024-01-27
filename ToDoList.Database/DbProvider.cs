using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
namespace ToDoList.Database
{

	/// <inheritdoc cref="IDbProvider"/>
	/// <summary>
	/// Создаёт экземпляр <see cref="DbProvider"/>.
	/// </summary>
	/// <param name="serviceProvider">Провайдер сервисов.</param>
	public class DbProvider(IServiceProvider serviceProvider, ILogger<DbProvider> logger) : IDbProvider
	{
		

		/// <summary>Провайдер сервисов.</summary>
		private readonly IServiceProvider _serviceProvider = serviceProvider;

		private readonly ILogger _logger = logger;

		

		/// <summary>Проинициализирована ли база данных</summary>
		public bool IsInit { get; private set; }

		/// <inheritdoc />
		public async ValueTask<ToDoListContext> GetAsync(CancellationToken cancellationToken = default)
		{
			var serviceScope = _serviceProvider.CreateAsyncScope();
			var dbContext = serviceScope.ServiceProvider.GetRequiredService<ToDoListContext>();
			if (IsInit) return dbContext;
			if (!IsInit)
				{
					_logger.LogInformation("Begin database initialization");

					await dbContext.Database.MigrateAsync(cancellationToken);

					_logger.LogInformation("Database initialized");
					IsInit = true;
				}

			return dbContext;
		}
	}

}
