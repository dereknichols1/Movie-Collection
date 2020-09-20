using System;
using MovieCollections.Models;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MovieCollections.DataAccess.Data.Repository.IRepository
{
    public interface IMovieItemRepository : IRepository<MovieItem>
    {
        void Update(MovieItem foodType);
    }
}
