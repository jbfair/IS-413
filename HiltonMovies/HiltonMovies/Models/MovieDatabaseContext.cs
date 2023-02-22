using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiltonMovies.Models
{
    public class MovieDatabaseContext : DbContext
    {
        public MovieDatabaseContext (DbContextOptions<MovieDatabaseContext> options): base (options)
        {

        }

        public DbSet<MovieModel> responses { get; set; }
        public DbSet<Category> categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {

            mb.Entity<Category>().HasData(
                new Category
                {
                    CategoryID = 1,
                    CategoryName = "Comedy"
                },
                new Category
                {
                    CategoryID = 2,
                    CategoryName = "Sports"
                },
                new Category
                {
                    CategoryID = 3,
                    CategoryName = "Comedy/Adventure"
                },
                new Category
                {
                    CategoryID = 4,
                    CategoryName = "Action/Adventure"
                }
                );
            mb.Entity<MovieModel>().HasData(
                new MovieModel
                {
                    MovieID = 1,
                    CategoryID = 1,
                    Title = "Dumb and Dumber",
                    Year = 1994,
                    Director = "Peter Farrelly",
                    Rating = "PG-13",
                },
                new MovieModel
                {
                    MovieID = 2,
                    CategoryID = 2,
                    Title = "Remember the Titans",
                    Year = 2000,
                    Director = "Boaz Yakin",
                    Rating = "PG",
                },
                new MovieModel
                {
                    MovieID = 3,
                    CategoryID = 3,
                    Title = "Fantastic Mr. Fox",
                    Year = 2009,
                    Director = "Wes Anderson",
                    Rating = "PG",

                }
                );
        }
    }
}
