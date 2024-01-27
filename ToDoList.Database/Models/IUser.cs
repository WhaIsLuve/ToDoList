namespace ToDoList.Database.Models
{
	/// <summary>Пользователь.</summary>
	public interface IUser
	{
		/// <summary>Id пользователя.</summary>
		long Id { get; }

		/// <summary>Имя пользователя.</summary>
		string Name { get; }

		/// <summary>Email пользователя.</summary>
		string Email { get; }

		/// <summary>Пароль пользователя.</summary>
		string Password { get; }

		/// <summary>Список дел.</summary>
		IEnumerable<ToDo> ToDos { get; }
	}
}
