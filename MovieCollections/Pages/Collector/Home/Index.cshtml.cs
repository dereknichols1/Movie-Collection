using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieCollections.DataAccess.Data.Repository.IRepository;
using MovieCollections.Models;

namespace MovieCollections.Pages.Collector.Home
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Collections> CollectionsList { get; set; }
        public IEnumerable<MovieItem> MovieItemList { get; set; }
        public IEnumerable<Movie> MovieList { get; set; }

        public string UserId { get; set; }

        public void OnGet()
        {
            CollectionsList = _unitOfWork.Collections.GetAll();
            MovieItemList = _unitOfWork.MovieItem.GetAll(null, null, "Movie");
            MovieList = _unitOfWork.Movie.GetAll();


            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            if (claim != null)
            {
                UserId = claim.Value;

            }
        }
    }
}
