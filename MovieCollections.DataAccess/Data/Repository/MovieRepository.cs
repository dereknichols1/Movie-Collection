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

        public IEnumerable<SelectListItem> GetMovieListForDropDown()
        {
            return _db.Movie.Select(i => new SelectListItem()
            {
                Text = i.Title,
                Value = i.Id.ToString()
            });
        }

        public void Update(Movie movie)
        {
            var objFromDb = _db.Movie.FirstOrDefault(s => s.Id == movie.Id);

            objFromDb.Title = movie.Title;
            objFromDb.Rating = movie.Rating;
            objFromDb.Length = movie.Length;
            objFromDb.MyComments = movie.MyComments;

            if (movie.Image != null)
            {
                objFromDb.Image = movie.Image;
            }

            _db.SaveChanges();
        }
    }
}
