﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ToDoList.Database;

#nullable disable

namespace ToDoList.Database.Migrations
{
	[DbContext(typeof(ToDoListContext))]
	partial class ToDoListContextModelSnapshot : ModelSnapshot
	{
		protected override void BuildModel(ModelBuilder modelBuilder)
		{
#pragma warning disable 612, 618
			modelBuilder
				.HasAnnotation("ProductVersion", "8.0.0")
				.HasAnnotation("Relational:MaxIdentifierLength", 63);

			NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

			modelBuilder.Entity("ToDoList.Database.Models.ToDo", b =>
				{
					b.Property<long>("Id")
						.ValueGeneratedOnAdd()
						.HasColumnType("bigint")
						.HasColumnName("Id");

					NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

					b.Property<string>("Description")
						.HasColumnType("text")
						.HasColumnName("Description");

					b.Property<bool>("IsDone")
						.ValueGeneratedOnAdd()
						.HasColumnType("boolean")
						.HasDefaultValue(false)
						.HasColumnName("IsDone");

					b.Property<string>("Title")
						.IsRequired()
						.HasColumnType("text")
						.HasColumnName("Title");

					b.Property<long>("UserId")
						.HasColumnType("bigint");

					b.HasKey("Id");

					b.HasIndex("UserId");

					b.ToTable("ToDos", (string)null);
				});

			modelBuilder.Entity("ToDoList.Database.Models.User", b =>
				{
					b.Property<long>("Id")
						.ValueGeneratedOnAdd()
						.HasColumnType("bigint")
						.HasColumnName("Id");

					NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

					b.Property<string>("Email")
						.IsRequired()
						.HasColumnType("text")
						.HasColumnName("Email");

					b.Property<string>("Name")
						.IsRequired()
						.HasColumnType("text")
						.HasColumnName("Name");

					b.Property<string>("Password")
						.IsRequired()
						.HasColumnType("text")
						.HasColumnName("HashPassword");

					b.HasKey("Id");

					b.ToTable("Users", (string)null);
				});

			modelBuilder.Entity("ToDoList.Database.Models.ToDo", b =>
				{
					b.HasOne("ToDoList.Database.Models.User", "User")
						.WithMany("ToDos")
						.HasForeignKey("UserId")
						.OnDelete(DeleteBehavior.Cascade)
						.IsRequired();

					b.Navigation("User");
				});

			modelBuilder.Entity("ToDoList.Database.Models.User", b =>
				{
					b.Navigation("ToDos");
				});
#pragma warning restore 612, 618
		}
	}
}
