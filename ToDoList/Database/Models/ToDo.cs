namespace ToDoList.Database.Models
{
	/// <summary>Дело.</summary>
	public class ToDo : IToDo
	{

		public ToDo(long id, string title, string? description)
		{
			Id = id;
			Title = title;
			Description = description;
			IsDone = false;
		}

		/// <inheritdoc/>
		public long Id { get; set; }

		/// <inheritdoc/>
		public string Title { get; set; }
		/// <inheritdoc/>
		public string? Description { get; set; }

		/// <inheritdoc/>
		public bool IsDone { get; set; }
	}
}
