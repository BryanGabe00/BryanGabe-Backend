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

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public bool AddUser(User user)
        {
            bool result = false;
            BryanGabeDAL.Models.User userObj = new ()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                DisplayName = user.DisplayName,
                Email = user.Email,
                HashPassword = user.HashPassword,
                Dob = user.Dob,
                LastLogin = user.LastLogin,
                DateCreated = user.DateCreated,
                RoleId = user.RoleId,
                Deleted = user.Deleted
            };
            try
            {
                _repo.AddUser(userObj);
                result = true;
            } catch
            {
                Console.WriteLine("ERRRR");
            }
            return result;
        }
    }
}

