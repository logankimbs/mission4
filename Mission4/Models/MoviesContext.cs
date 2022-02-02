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
        public DbSet<MoviesCategoryModel> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<MoviesCategoryModel>().HasData(
                new MoviesCategoryModel { CategoryId = 1, Category = "Action/Adventure" },
                new MoviesCategoryModel { CategoryId = 2, Category = "Comedy" },
                new MoviesCategoryModel { CategoryId = 3, Category = "Drama" },
                new MoviesCategoryModel { CategoryId = 4, Category = "Family" },
                new MoviesCategoryModel { CategoryId = 5, Category = "Horror/Suspense" },
                new MoviesCategoryModel { CategoryId = 6, Category = "Miscellaneous" },
                new MoviesCategoryModel { CategoryId = 7, Category = "Television" },
                new MoviesCategoryModel { CategoryId = 8, Category = "VHS" }
            );

            mb.Entity<MoviesModel>().HasData(
                new MoviesModel
                {
                    MovieId = 1,
                    CategoryId = 1,
                    Title = "The Avengers",
                    Year = "2012",
                    Director = "Joss Whedon",
                    Rating = "PG-13"
                },

                new MoviesModel
                {
                    MovieId = 2,
                    CategoryId = 2,
                    Title = "Anchorman",
                    Year = "2004",
                    Director = "Adam McKay",
                    Rating = "PG-13"
                },

                new MoviesModel
                {
                    MovieId = 3,
                    CategoryId = 3,
                    Title = "127 Hours",
                    Year = "2010",
                    Director = "Danny Boyle",
                    Rating = "R"
                }
            );
        }
    }
}
