using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ToDoList.Database.Models
{
	/// <summary>Пользователь.</summary>
	public class User(long id, string name, string email, string password) : IUser
	{
		#region Configuration

		private sealed class Configuration : IEntityTypeConfiguration<User>
		{
			/// <inheritdoc />
			public void Configure(EntityTypeBuilder<User> builder)
			{
				builder.ToTable("Users");

				builder.HasKey(e => e.Id);

				builder
					.Property(e => e.Id)
					.HasColumnName("Id")
					.ValueGeneratedOnAdd()
					.IsRequired();

				builder
					.Property(e => e.Name)
					.HasColumnName("Name")
					.IsRequired();
				builder
					.Property(e => e.Email)
					.HasColumnName("Email")
					.IsRequired();

				builder
					.Property(e => e.Password)
					.HasColumnName("HashPassword")
					.IsRequired();
			}
		}

		#endregion

		/// <inheritdoc/>
		public long Id { get; set; } = id;

		/// <inheritdoc/>
		public string Name { get; set; } = name;

		/// <inheritdoc/>
		public string Email { get; set;	} = email;

		/// <inheritdoc/>
		public string Password { get; set; } = password;

		/// <inheritdoc/>
		public IEnumerable<ToDo> ToDos { get; set;	}

		public static IEntityTypeConfiguration<User> GetConfiguration => new Configuration();
	}
}
