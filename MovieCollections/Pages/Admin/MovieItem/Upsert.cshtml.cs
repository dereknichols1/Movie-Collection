using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieCollections.DataAccess.Data.Repository.IRepository;
using MovieCollections.Models;
using MovieCollections.Models.ViewModels;

namespace MovieCollections.Pages.Admin.MovieItem
{
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpsertModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Collections> CollectionsList { get; set; }

        [BindProperty]
        public MovieItemVM MovieItemObj { get; set; }

        public IActionResult OnGet(int? id)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var isAdmin = User.IsInRole(MovieCollections.Utility.SD.AdminRole);

            MovieItemObj = new MovieItemVM
            {
                MovieItem = new Models.MovieItem(),
                MovieList = _unitOfWork.Movie.GetMovieListForDropDown(),
                CollectionsList = isAdmin ? _unitOfWork.Collections.GetCollectionsListForDropDown() : _unitOfWork.Collections.GetCollectionsListForDropDown(claim.Value)
            };
  
            if (id != null)
            {
                if (claim != null)
                {
                    Models.MovieItem movieItem = _unitOfWork.MovieItem.GetFirstOrDefault(c => c.UserId == claim.Value);
                    MovieItemObj.MovieItem = movieItem;

                    //MovieItemObj.MovieItem = _unitOfWork.MovieItem.GetFirstOrDefault(u => u.Id == id);

                    if (MovieItemObj == null)
                    {
                        return NotFound();
                    }
                }
            }

            return Page(); //refresh page call onGet again without id

        }

        public IActionResult OnPost()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (MovieItemObj.MovieItem.Id == 0) //means a brand new movie item
            {
                MovieItemObj.MovieItem.UserId = claim.Value;
                _unitOfWork.MovieItem.Add(MovieItemObj.MovieItem);
            }

            else
            {
                _unitOfWork.MovieItem.Update(MovieItemObj.MovieItem);
            }

            _unitOfWork.Save();
            return RedirectToPage("./Index");
        }
    }
}

