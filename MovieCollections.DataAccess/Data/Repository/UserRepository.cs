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

        public void Update(User user)
        {
            var itemFromDb = _db.User.FirstOrDefault(m => m.Id == user.Id);

            itemFromDb.MovieId = user.MovieId;

            _db.SaveChanges();
        }

        }
}
