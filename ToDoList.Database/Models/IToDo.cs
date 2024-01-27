namespace ToDoList.Database.Models
{
	/// <summary>Дело.</summary>
	public interface IToDo
	{
		/// <summary>Id дела.</summary>
		long Id { get; }

		/// <summary>Название дела.</summary>
		string Title { get; }

		/// <summary>Описание дела.</summary>
		string? Description { get; }

		/// <summary>Выполнено ли задание.</summary>
		bool IsDone { get; }

		/// <summary>Id пользователя.</summary>
		long UserId { get; }

		/// <summary>Пользователь.</summary>
		User User { get; }
	}
}
