using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BryanGabeAPI.Models;
using BryanGabeDAL.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BryanGabeAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly AdminRepository _repo;

        public UserController(AdminRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public JsonResult GetActiveUsers()
        {
            List<BryanGabeDAL.Models.User> users = new List<BryanGabeDAL.Models.User>();
            users = _repo.GetActiveUsers();
            return Json(users);
        }

        [HttpPost]
        public bool AddUser(User user)
        {
            bool result = false;

            if(ModelState.IsValid)
            {
                BryanGabeDAL.Models.RegisterUser userObj = new()
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    DisplayName = user.DisplayName,
                    Email = user.Email,
                    Password = user.Password,
                    Dob = user.Dob,
                    RoleId = user.RoleId,
                };
                try
                {
                    _repo.AddUser(userObj);
                    result = true;
                }
                catch
                {
                    result = false;
                }
            }
            
            return result;
        }

        [HttpPost]
        public bool DeleteUser(int id)
        {
            bool result = false;
            try
            {
                _repo.DeleteUser(id);
                result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }
    }
}

