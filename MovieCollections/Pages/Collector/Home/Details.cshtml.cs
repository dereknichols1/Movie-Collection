using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieCollections.Models;
using MovieCollections.DataAccess.Data.Repository.IRepository;

namespace MovieCollections.Pages.Collector.Home
{
    public class DetailsModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public DetailsModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public Movie MovieObj { get; set; }

        public IActionResult OnGet(int id)
        {
            MovieObj = _unitOfWork.Movie.GetFirstOrDefault(u => u.Id == id);

            if (MovieObj == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
