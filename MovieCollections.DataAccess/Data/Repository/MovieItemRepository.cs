using MovieCollections.DataAccess.Data.Repository.IRepository;
using MovieCollections.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieCollections.DataAccess.Data.Repository
{
    public class MovieItemRepository : Repository<MovieItem>, IMovieItemRepository
    {
        private readonly ApplicationDbContext _db;

        public MovieItemRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(MovieItem movieItem)
        {
            var objFromDb = _db.MovieItem.FirstOrDefault(s => s.Id == movieItem.Id);

            objFromDb.MovieFormat = movieItem.MovieFormat;

            _db.SaveChanges();
        }
    }
}
