using Microsoft.AspNetCore.Mvc.Rendering;
using MovieCollections.DataAccess.Data.Repository.IRepository;
using MovieCollections.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieCollections.DataAccess.Data.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {

        private readonly ApplicationDbContext _db;

        public UserRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetUserForDropDown()
        {
            return _db.User.Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
        }

        public void Update(User user)
        {
            var objFromDb = _db.User.FirstOrDefault(s => s.Id == user.Id);

            objFromDb.Name = user.Name;
            objFromDb.MoviesOwned = user.MoviesOwned;

            _db.SaveChanges();
        }
    }
}
