using Microsoft.AspNetCore.Mvc.Rendering;
using MovieCollections.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieCollections.DataAccess.Data.Repository.IRepository
{
    public interface IMovieRepository : IRepository<Movie>
    {
        IEnumerable<SelectListItem> GetMovieListForDropDown();

        void Update(Movie foodType);
    }
}
