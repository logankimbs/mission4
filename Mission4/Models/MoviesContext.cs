using System;
using Microsoft.EntityFrameworkCore;

namespace Mission4.Models
{
    public class MoviesContext : DbContext
    {
        public MoviesContext(DbContextOptions<MoviesContext> options) : base(options)
        {

        }

        public DbSet<MoviesModel> Responses { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<MoviesModel>().HasData(
                new MoviesModel
                {
                    MovieId = 1,
                    Category = "Action/Adventure",
                    Title = "The Avengers",
                    Year = "2012",
                    Director = "Joss Whedon",
                    Rating = "PG-13"
                },

                new MoviesModel
                {
                    MovieId = 2,
                    Category = "Comedy",
                    Title = "Anchorman",
                    Year = "2004",
                    Director = "Adam McKay",
                    Rating = "PG-13"
                },

                new MoviesModel
                {
                    MovieId = 3,
                    Category = "Drama",
                    Title = "127 Hours",
                    Year = "2010",
                    Director = "Danny Boyle",
                    Rating = "R"
                }
            );
        }
    }
}
