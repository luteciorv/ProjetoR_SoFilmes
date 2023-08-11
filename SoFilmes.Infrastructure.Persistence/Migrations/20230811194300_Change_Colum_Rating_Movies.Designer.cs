﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SoFilmes.Infrastructure.Persistence.Context;

#nullable disable

namespace SoFilmes.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230811194300_Change_Colum_Rating_Movies")]
    partial class Change_Colum_Rating_Movies
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SoFilmes.Domain.Entities.Genre", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("SoFilmes.Domain.Entities.Movie", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("AgeClassification")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("DurationInMinutes")
                        .HasColumnType("int");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("SoFilmes.Domain.Entities.MovieGenre", b =>
                {
                    b.Property<Guid>("MovieId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("GenreId")
                        .HasColumnType("char(36)");

                    b.HasKey("MovieId", "GenreId");

                    b.HasIndex("GenreId");

                    b.ToTable("MoviesGenres");
                });

            modelBuilder.Entity("SoFilmes.Domain.Entities.MovieGenre", b =>
                {
                    b.HasOne("SoFilmes.Domain.Entities.Genre", "Genre")
                        .WithMany("MoviesGenres")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SoFilmes.Domain.Entities.Movie", "Movie")
                        .WithMany("MoviesGenres")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("SoFilmes.Domain.Entities.Genre", b =>
                {
                    b.Navigation("MoviesGenres");
                });

            modelBuilder.Entity("SoFilmes.Domain.Entities.Movie", b =>
                {
                    b.Navigation("MoviesGenres");
                });
#pragma warning restore 612, 618
        }
    }
}
