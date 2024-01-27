namespace ToDoList.Database
{
	public interface IDbProvider
	{
		/// <summary>
		/// Получает асинхронно экземпляр контекста базы данных менеджера камер.
		/// </summary>
		/// <param name="cancellationToken">Токен на отмену операции.</param>
		/// <returns>Асинхронная задача по получению экземпляра <see cref="TodoListContext"/>.</returns>
		ValueTask<ToDoListContext> GetAsync(CancellationToken cancellationToken = default);
	}
}