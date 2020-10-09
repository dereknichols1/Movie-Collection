using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using MovieCollections.DataAccess.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCollections.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieItemController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public MovieItemController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Json(new { data = _unitOfWork.MovieItem.GetAll() });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.MovieItem.GetFirstOrDefault(u => u.Id == id);

            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            _unitOfWork.MovieItem.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful" });
        }
    }
}
