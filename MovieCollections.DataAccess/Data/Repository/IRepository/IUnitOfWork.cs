using System;
using System.Collections.Generic;
using System.Text;

namespace MovieCollections.DataAccess.Data.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        ICollectionsRepository Collections { get; }

        IMovieRepository Movie { get; }

        IMovieItemRepository MovieItem { get; }

        IUserRepository User { get; }

        void Save();
    }
}
