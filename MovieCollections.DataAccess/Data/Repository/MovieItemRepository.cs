using Microsoft.AspNetCore.Mvc.Rendering;
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

        public IEnumerable<SelectListItem> GetMovieItemListForDropDown()
        {
            return _db.MovieItem.Select(i => new SelectListItem()
            {
                Text = i.Movie.Title,
                Value = i.Id.ToString()
            });
        }

        public void Update(MovieItem movieItem)
        {
            var objFromDb = _db.MovieItem.FirstOrDefault(s => s.Id == movieItem.Id);

            objFromDb.MovieId = movieItem.MovieId;
            objFromDb.CollectionsId = movieItem.CollectionsId;
            objFromDb.MovieFormat = movieItem.MovieFormat;
            objFromDb.ItemCondition = movieItem.ItemCondition;
            objFromDb.UserId = movieItem.UserId;

            _db.SaveChanges();
        }
    }
}
