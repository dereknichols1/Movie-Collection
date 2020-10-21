using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieCollections.DataAccess.Data.Repository.IRepository;
using MovieCollections.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
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
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var isAdmin = User.IsInRole(Utility.SD.AdminRole);

            HttpContext.Session.SetString(SD.MovieItem, "Movie Item");

            JsonResult jsonResult = null;

            if (isAdmin)
            {
                jsonResult = Json(new { data = _unitOfWork.MovieItem.GetAll(null, null, "Movie,Collections") });
            }
            else
            {
                jsonResult = Json(new { data = _unitOfWork.MovieItem.GetAll(c => c.UserId.Equals(claim.Value), null, "Movie,Collections") });
            }
            return jsonResult;

            //return Json(new { data = _unitOfWork.MovieItem.GetAll(null, null, "Movie,Collections") });
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
