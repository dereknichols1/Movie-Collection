﻿using Microsoft.AspNetCore.Mvc;
using MovieCollections.DataAccess.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCollections.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Get()
        {

            return Json(new { data = _unitOfWork.User.GetAll() });
        }

        [HttpPost]
        public IActionResult LockUnlock([FromBody] string id)
        {
            var objFromDb = _unitOfWork.User.GetFirstOrDefault(u => u.Id == id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while Locking / Unlocking" });
            }

            if (objFromDb.LockoutEnd != null && objFromDb.LockoutEnd > DateTime.Now)
            {
                //User is currently locked out so unlock them
                objFromDb.LockoutEnd = DateTime.Now;
            }

            else
            {
                //lock user
                objFromDb.LockoutEnd = DateTime.Now.AddYears(100);
            }


            _unitOfWork.Save();
            return Json(new { success = true, message = "Lock/Unlock Successful" });

        }
    }
}
