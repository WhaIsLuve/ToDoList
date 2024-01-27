using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ToDoList.Database.Models
{
	/// <summary>Дело.</summary>
	public class ToDo(string title, string? description, long userId) : IToDo
	{
		#region Configuration

		private sealed class Configuration : IEntityTypeConfiguration<ToDo>
		{
			/// <inheritdoc />
			public void Configure(EntityTypeBuilder<ToDo> builder)
			{
				builder.ToTable("ToDos");

				builder.HasKey(e => e.Id);

				builder
					.Property(e => e.Id)
					.HasColumnName("Id")
					.ValueGeneratedOnAdd()
					.IsRequired();

				builder
					.Property(e => e.Title)
					.HasColumnName("Title")
					.IsRequired();

				builder
					.Property(e => e.Description)
					.HasColumnName("Description")
					.IsRequired(false);

				builder
					.Property(e => e.IsDone)
					.HasColumnName("IsDone")
					.IsRequired()
					.HasDefaultValue(false);


				builder
					.HasOne(e => e.User)
					.WithMany(e => e.ToDos)
					.HasForeignKey(e => e.UserId)
					.IsRequired();
			}
		}

		#endregion

		/// <inheritdoc/>
		public long Id { get; set; }

		/// <inheritdoc/>
		public string Title { get; set; } = title;
		/// <inheritdoc/>
		public string? Description { get; set; } = description;

		/// <inheritdoc/>
		public bool IsDone { get; set; } = false;

		/// <inheritdoc/>
		public long UserId { get; set; } = userId;

		/// <inheritdoc/>
		public User User { get; set; }

		public static IEntityTypeConfiguration<ToDo> GetConfiguration => new Configuration();
	}
}
