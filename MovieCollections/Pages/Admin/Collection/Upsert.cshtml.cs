using System;
using System.Collections.Generic;
using System.Linq;
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
            CollectionsObj = new Models.Collections();

            if (id != null)
            {
                CollectionsObj = _unitOfWork.Collections.GetFirstOrDefault(u => u.Id == id);

                if (CollectionsObj == null)
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

            if (CollectionsObj.Id == 0) //means a brand new collection
            {
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
