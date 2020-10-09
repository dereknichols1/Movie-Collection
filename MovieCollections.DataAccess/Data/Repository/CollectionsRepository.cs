using Microsoft.AspNetCore.Mvc.Rendering;
using MovieCollections.DataAccess.Data.Repository.IRepository;
using MovieCollections.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieCollections.DataAccess.Data.Repository
{
    public class CollectionsRepository : Repository<Collections>, ICollectionsRepository
    {

        private readonly ApplicationDbContext _db;

        public CollectionsRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetCollectionsListForDropDown()
        {
            return _db.Collections.Select(i => new SelectListItem()
            {
                Text = i.MovieItem.Movie.Title,
                Value = i.Id.ToString()
            });
        }

        public void Update(Collections collections)
        {
            var objFromDb = _db.Collections.FirstOrDefault(s => s.Id == collections.Id);

            objFromDb.MovieItemId = collections.MovieItemId;
            objFromDb.ItemCondition = collections.ItemCondition;
            objFromDb.MyRating = collections.MyRating;
            objFromDb.MyComments = collections.MyComments;

            _db.SaveChanges();
        }
    }
}
