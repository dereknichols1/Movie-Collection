using Microsoft.AspNetCore.Mvc.Rendering;
using MovieCollections.DataAccess.Data.Repository.IRepository;
using MovieCollections.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieCollections.DataAccess.Data.Repository
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        private readonly ApplicationDbContext _db;

        public MovieRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Movie movie)
        {
            var objFromDb = _db.Movie.FirstOrDefault(s => s.Id == movie.Id);

            objFromDb.Title = movie.Title;
            objFromDb.Rating = movie.Rating;
            objFromDb.Length = movie.Length;
            objFromDb.UserId = movie.UserId;

            if (movie.Image != null)
            {
                objFromDb.Image = movie.Image;
            }

            _db.SaveChanges();
        }
    }
}
