using Microsoft.Extensions.Hosting;
using ToDoList.Database;

namespace ToDoList.Infrastructure
{
	public class DbInit(IDbProvider dbProvider) : BackgroundService
	{
		private readonly IDbProvider _dbProvider = dbProvider;

		protected override async Task ExecuteAsync(CancellationToken cancellationToken)
		{
			await _dbProvider.GetAsync(cancellationToken);
		}
	}
}
