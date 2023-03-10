// <auto-generated />
using HiltonMovies.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HiltonMovies.Migrations
{
    [DbContext(typeof(MovieDatabaseContext))]
    partial class MovieDatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.32");

            modelBuilder.Entity("HiltonMovies.Models.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CategoryName")
                        .HasColumnType("TEXT");

                    b.HasKey("CategoryID");

                    b.ToTable("categories");

                    b.HasData(
                        new
                        {
                            CategoryID = 1,
                            CategoryName = "Comedy"
                        },
                        new
                        {
                            CategoryID = 2,
                            CategoryName = "Sports"
                        },
                        new
                        {
                            CategoryID = 3,
                            CategoryName = "Comedy/Adventure"
                        },
                        new
                        {
                            CategoryID = 4,
                            CategoryName = "Action/Adventure"
                        });
                });

            modelBuilder.Entity("HiltonMovies.Models.MovieModel", b =>
                {
                    b.Property<int>("MovieID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoryID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Edited")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Lent")
                        .HasColumnType("TEXT");

                    b.Property<string>("Notes")
                        .HasColumnType("TEXT")
                        .HasMaxLength(25);

                    b.Property<string>("Rating")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Year")
                        .HasColumnType("INTEGER");

                    b.HasKey("MovieID");

                    b.HasIndex("CategoryID");

                    b.ToTable("responses");

                    b.HasData(
                        new
                        {
                            MovieID = 1,
                            CategoryID = 1,
                            Director = "Peter Farrelly",
                            Edited = false,
                            Rating = "PG-13",
                            Title = "Dumb and Dumber",
                            Year = 1994
                        },
                        new
                        {
                            MovieID = 2,
                            CategoryID = 2,
                            Director = "Boaz Yakin",
                            Edited = false,
                            Rating = "PG",
                            Title = "Remember the Titans",
                            Year = 2000
                        },
                        new
                        {
                            MovieID = 3,
                            CategoryID = 3,
                            Director = "Wes Anderson",
                            Edited = false,
                            Rating = "PG",
                            Title = "Fantastic Mr. Fox",
                            Year = 2009
                        });
                });

            modelBuilder.Entity("HiltonMovies.Models.MovieModel", b =>
                {
                    b.HasOne("HiltonMovies.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
