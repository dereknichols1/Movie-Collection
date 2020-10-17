using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieCollections.DataAccess.Data.Repository.IRepository;
using MovieCollections.Models.ViewModels;

namespace MovieCollections.Pages.Admin.Collection
{
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpsertModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public Models.Collections CollectionsObj { get; set; }

        public IActionResult OnGet(int? id)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            CollectionsObj = new Models.Collections();

            if (id != null)
            {

                if(claim != null)
                {
                    Models.Collections collection = _unitOfWork.Collections.GetFirstOrDefault(u => u.UserId == claim.Value);
                    CollectionsObj = collection;

                    if (CollectionsObj == null)
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

            if (CollectionsObj.Id == 0) //means a brand new collection
            {
                CollectionsObj.UserId = claim.Value;
                _unitOfWork.Collections.Add(CollectionsObj);
            }

            else
            {
                _unitOfWork.Collections.Update(CollectionsObj);
            }

            _unitOfWork.Save();
            return RedirectToPage("./Index");
        }


    }
}
