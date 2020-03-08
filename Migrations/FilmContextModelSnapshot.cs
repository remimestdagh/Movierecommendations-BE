﻿// <auto-generated />
using System;
using BackEndRemiMestdagh.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BackEndRemiMestdagh.Migrations
{
    [DbContext(typeof(FilmContext))]
    partial class FilmContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BackEndRemiMestdagh.Models.Acteur", b =>
                {
                    b.Property<int>("ActeurId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasMaxLength(50)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naam")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ActeurId");

                    b.ToTable("Acteurs");
                });

            modelBuilder.Entity("BackEndRemiMestdagh.Models.ActeurFilm", b =>
                {
                    b.Property<int>("ActeurId")
                        .HasColumnType("int");

                    b.Property<int>("FilmId")
                        .HasColumnType("int");

                    b.HasKey("ActeurId", "FilmId");

                    b.HasIndex("FilmId");

                    b.ToTable("ActeurFilm");
                });

            modelBuilder.Entity("BackEndRemiMestdagh.Models.Film", b =>
                {
                    b.Property<int>("FilmId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("RegisseurId")
                        .HasColumnType("int");

                    b.Property<double>("Runtime")
                        .HasColumnType("float");

                    b.Property<double>("Score")
                        .HasColumnType("float");

                    b.Property<string>("Titel")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("TitleImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("FilmId");

                    b.HasIndex("RegisseurId");

                    b.ToTable("Films");
                });

            modelBuilder.Entity("BackEndRemiMestdagh.Models.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naam")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GenreId");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("BackEndRemiMestdagh.Models.GenreFilm", b =>
                {
                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<int>("FilmId")
                        .HasColumnType("int");

                    b.HasKey("GenreId", "FilmId");

                    b.HasIndex("FilmId");

                    b.ToTable("GenreFilm");
                });

            modelBuilder.Entity("BackEndRemiMestdagh.Models.Regisseur", b =>
                {
                    b.Property<int>("RegisseurId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naam")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RegisseurId");

                    b.ToTable("Regisseurs");
                });

            modelBuilder.Entity("BackEndRemiMestdagh.Models.ActeurFilm", b =>
                {
                    b.HasOne("BackEndRemiMestdagh.Models.Acteur", "Acteur")
                        .WithMany()
                        .HasForeignKey("ActeurId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackEndRemiMestdagh.Models.Film", "Film")
                        .WithMany("Acteurs")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BackEndRemiMestdagh.Models.Film", b =>
                {
                    b.HasOne("BackEndRemiMestdagh.Models.Regisseur", "Regisseur")
                        .WithMany()
                        .HasForeignKey("RegisseurId");
                });

            modelBuilder.Entity("BackEndRemiMestdagh.Models.GenreFilm", b =>
                {
                    b.HasOne("BackEndRemiMestdagh.Models.Film", "Film")
                        .WithMany("Genres")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackEndRemiMestdagh.Models.Genre", "Genre")
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
