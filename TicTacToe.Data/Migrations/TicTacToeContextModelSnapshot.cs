﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TicTacToe.Data;

#nullable disable

namespace TicTacToe.Data.Migrations
{
    [DbContext(typeof(TicTacToeContext))]
    partial class TicTacToeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TicTacToe.Contracts.Game", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Board")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GameMode")
                        .HasColumnType("int");

                    b.Property<bool>("IsComplete")
                        .HasColumnType("bit");

                    b.Property<string>("OPlayerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlayerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Winner")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("XPlayerId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("XTurn")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("TicTacToe.Contracts.Player", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Players");

                    b.HasData(
                        new
                        {
                            Id = "computer",
                            Email = "computer@gmail.com",
                            Name = "Computer",
                            Password = "12345678"
                        });
                });

            modelBuilder.Entity("TicTacToe.Contracts.Game", b =>
                {
                    b.HasOne("TicTacToe.Contracts.Player", null)
                        .WithMany("Games")
                        .HasForeignKey("PlayerId");
                });

            modelBuilder.Entity("TicTacToe.Contracts.Player", b =>
                {
                    b.Navigation("Games");
                });
#pragma warning restore 612, 618
        }
    }
}
