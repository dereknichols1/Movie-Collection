using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieCollections.DataAccess.Data.Repository.IRepository;
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

        [BindProperty]
        public MovieItemVM MovieItemObj { get; set; }

        public IActionResult OnGet(int? id)
        {
            MovieItemObj = new MovieItemVM
            {
                MovieItem = new Models.MovieItem(),
                MovieList = _unitOfWork.Movie.GetMovieListForDropDown(),
                CollectionsList = _unitOfWork.Collections.GetCollectionsListForDropDown()
            };

            if (id != null)
            {
                MovieItemObj.MovieItem = _unitOfWork.MovieItem.GetFirstOrDefault(u => u.Id == id);

                if (MovieItemObj == null)
                {
                    return NotFound();
                }
            }

            return Page(); //refresh page call onGet again without id

        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (MovieItemObj.MovieItem.Id == 0) //means a brand new movie item
            {
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

