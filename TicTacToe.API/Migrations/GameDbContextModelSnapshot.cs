// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TicTacToe.API.BLL.Models;
using TicTacToe.API.DAL.Repositories.Contexts;

#nullable disable

namespace TicTacToe.API.Migrations
{
    [DbContext(typeof(GameDbContext))]
    partial class GameDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.1.23111.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("TicTacToe.API.BLL.Models.Game", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("IsFinished")
                        .HasColumnType("boolean");

                    b.Property<Guid>("PlayerOId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PlayerXId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("RoomId")
                        .HasColumnType("uuid");

                    b.Property<List<Step>>("Steps")
                        .HasColumnType("jsonb");

                    b.Property<Guid?>("WinnerId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("TicTacToe.API.BLL.Models.Player", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("IsOnline")
                        .HasColumnType("boolean");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<byte[]>("SaltedPassword")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.HasKey("Id");

                    b.HasIndex("Nickname")
                        .IsUnique();

                    b.ToTable("Players");
                });

            modelBuilder.Entity("TicTacToe.API.BLL.Models.Room", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("TicTacToe.API.BLL.Models.Game", b =>
                {
                    b.HasOne("TicTacToe.API.BLL.Models.Room", null)
                        .WithMany("Games")
                        .HasForeignKey("RoomId");
                });

            modelBuilder.Entity("TicTacToe.API.BLL.Models.Room", b =>
                {
                    b.Navigation("Games");
                });
#pragma warning restore 612, 618
        }
    }
}
