using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
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
        public string NameSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public PaginatedList<Movie> Movies { get; set; }

        public void OnGet(string sortOrder, string searchString, string currentFilter, int? pageIndex)
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

            CurrentSort = sortOrder;

            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Movie> movies = _unitOfWork.Movie.GetAll().AsQueryable();
                         
            if (!string.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Title.ToUpper().Contains(searchString.ToUpper()));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    movies = movies.OrderByDescending(s => s.Title);
                    break;
                default:
                    movies = movies.OrderBy(s => s.Title);
                    break;
            }

            int pageSize = 3;
            Movies = PaginatedList<Movie>.Create(
                movies, pageIndex ?? 1, pageSize);

            MovieList = movies.ToList();
        }
    }
}
