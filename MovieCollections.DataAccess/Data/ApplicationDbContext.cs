using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MovieCollections.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
        {
        }

        public DbSet<MovieCollections.Models.Collections> Collections { get; set; }

        public DbSet<MovieCollections.Models.Movie> Movie { get; set; }

        public DbSet<MovieCollections.Models.MovieItem> MovieItem { get; set; }

        public DbSet<MovieCollections.Models.User> User { get; set; }

    }
}
