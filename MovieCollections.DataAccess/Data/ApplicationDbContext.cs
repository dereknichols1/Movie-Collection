using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieCollections.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
        {
        }

        public DbSet<MovieCollections.Models.Collections> Collections { get; set; }

        public DbSet<MovieCollections.Models.Movie> Movie { get; set; }

        public DbSet<MovieCollections.Models.MovieItem> MovieItem { get; set; }

        public DbSet<MovieCollections.Models.User> User { get; set; }

        public DbSet<MovieCollections.Models.UserMovie> UserMovie { get; set; }
    }
}
