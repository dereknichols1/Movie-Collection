using Microsoft.AspNetCore.Mvc;
using MovieCollections.DataAccess.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MovieCollections.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CollectionsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var isAdmin = User.IsInRole(Utility.SD.AdminRole);

            JsonResult jsonResult = null;

            if (isAdmin)
            {
                jsonResult = Json(new { data = _unitOfWork.Collections.GetAll() });
            }
            else
            {
                jsonResult = Json(new { data = _unitOfWork.Collections.GetAll(c=> c.UserId.Equals(claim.Value)) });
            }
            return jsonResult;
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Collections.GetFirstOrDefault(u => u.Id == id);

            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            _unitOfWork.Collections.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful" });
        }
    }
}
