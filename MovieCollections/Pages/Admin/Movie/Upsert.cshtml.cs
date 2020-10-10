using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieCollections.DataAccess.Data.Repository.IRepository;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace MovieCollections.Pages.Admin.Movie
{
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public UpsertModel(IUnitOfWork unitOfWork, IWebHostEnvironment hostingEnvironment)
        {
            _unitOfWork = unitOfWork;
            _hostingEnvironment = hostingEnvironment;
        }

        [BindProperty]
        public Models.Movie MovieItemObj { get; set; }

        public IActionResult OnGet(int? id)
        {
            MovieItemObj = new Models.Movie { };

            if (id != null) //create new movie item
            {
                MovieItemObj = _unitOfWork.Movie.GetFirstOrDefault(u => u.Id == id);

                if (MovieItemObj == null)
                {
                    return NotFound();
                }
            }

            return Page(); //refresh page call onGet again without id

        }

        public IActionResult OnPost()
        {
            string webRootPath = _hostingEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;

            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (MovieItemObj.Id == 0) //means a brand new movie item
            {
                //Physically upload and save image
                string fileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(webRootPath, @"images\movies");
                var extension = Path.GetExtension(files[0].FileName);

                using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }

                MovieItemObj.Image = @"\images\movies\" + fileName + extension;

                _unitOfWork.Movie.Add(MovieItemObj);
            }

            else
            {
                var objFromDb = _unitOfWork.Movie.Get(MovieItemObj.Id);
                if (files.Count > 0)
                {

                    //Physically upload and save image
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(webRootPath, @"images\movies");
                    var extension = Path.GetExtension(files[0].FileName);

                    var imagePath = Path.Combine(webRootPath, objFromDb.Image.TrimStart('\\'));

                    if (System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);
                    }

                    using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        files[0].CopyTo(fileStream);
                    }

                    MovieItemObj.Image = @"\images\movies\" + fileName + extension;
                }
                else
                {
                    MovieItemObj.Image = objFromDb.Image;
                }

                _unitOfWork.Movie.Update(MovieItemObj);
            }

            _unitOfWork.Save();
            return RedirectToPage("./Index");
        }

    }
}
