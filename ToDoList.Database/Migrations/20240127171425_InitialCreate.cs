using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ToDoList.Database.Migrations
{
	/// <inheritdoc />
	public partial class InitialCreate : Migration
	{
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "Users",
				columns: table => new
				{
					Id = table.Column<long>(type: "bigint", nullable: false)
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					Name = table.Column<string>(type: "text", nullable: false),
					Email = table.Column<string>(type: "text", nullable: false),
					HashPassword = table.Column<string>(type: "text", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Users", x => x.Id);
				});

			migrationBuilder.CreateTable(
				name: "ToDos",
				columns: table => new
				{
					Id = table.Column<long>(type: "bigint", nullable: false)
						.Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
					Title = table.Column<string>(type: "text", nullable: false),
					Description = table.Column<string>(type: "text", nullable: true),
					IsDone = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
					UserId = table.Column<long>(type: "bigint", nullable: false)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_ToDos", x => x.Id);
					table.ForeignKey(
						name: "FK_ToDos_Users_UserId",
						column: x => x.UserId,
						principalTable: "Users",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.InsertData(
				table: "Users",
				columns: new[] { "Id", "Email", "Name", "HashPassword" },
				values: new object[] { 1L, "vladzernov2004g@gmail.com", "Admin", "ADXlRd0xV96s4JXzXVtkugIBkARgkXYXOvjS6Tl30n/XQc7u0KZcZ1ht/mBXpqhoyA==" });

			migrationBuilder.CreateIndex(
				name: "IX_ToDos_UserId",
				table: "ToDos",
				column: "UserId");
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "ToDos");

			migrationBuilder.DropTable(
				name: "Users");
		}
	}
}
