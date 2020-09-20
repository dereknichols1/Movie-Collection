using MovieCollections.DataAccess.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieCollections.DataAccess.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ApplicationDbContext _db;
        public ICollectionsRepository Collections { get; private set; }

        public IMovieRepository Movie { get; private set; }

        public IMovieItemRepository MovieItem { get; private set; }

        public IUserRepository User { get; private set; }

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Collections = new CollectionsRepository(_db);
            Movie = new MovieRepository(_db);
            MovieItem = new MovieItemRepository(_db);
            User = new UserRepository(_db);
        }


        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
