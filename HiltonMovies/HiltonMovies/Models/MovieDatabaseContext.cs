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

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<MovieModel>().HasData(
                new MovieModel
                {
                    MovieID = 1,
                    Category = "Comedy",
                    Title = "Dumb and Dumber",
                    Year = 1994,
                    Director = "Peter Farrelly",
                    Rating = "PG-13",
                },
                new MovieModel
                {
                    MovieID = 2,
                    Category = "Sports",
                    Title = "Remember the Titans",
                    Year = 2000,
                    Director = "Boaz Yakin",
                    Rating = "PG",
                },
                new MovieModel
                {
                    MovieID = 3,
                    Category = "Comedy/Adventure",
                    Title = "Fantastic Mr. Fox",
                    Year = 2009,
                    Director = "Wes Anderson",
                    Rating = "PG",

                }
                );
        }
    }
}
