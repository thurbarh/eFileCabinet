using DocumentServer.Data;
using DocumentServer.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentServer.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext db;

        public UserController(ApplicationDbContext db)
        {
            this.db = db;
        }
        private async Task<UserListViewModel> LoadAllUsers()
        {
            var viewModel = new UserListViewModel();
            viewModel.Users = await db.Users.Select(x => new UserViewModel
            {
                Id = x.Id,
                Username = x.Username,
                Password = x.Password,
                FullName = x.Fullname,

                UserGroupId = x.UserGroupId



            }).ToListAsync();
            return viewModel;

        }
        [HttpGet]
        public IActionResult GetAllUsers()
        {



            var model = db.Users.Select(x => new

            {
                Id = x.Id,  
                Username = x.Username,
                Password = x.Password,
                Fullname = x.Fullname,
                User_Group_Id = x.UserGroupId




            }).ToList();



            return Json(new { data = model });
        }

        public IActionResult Index()
        {
            var viewModel = new UserViewModel();
            ViewBag.Message = TempData["Message"];
            return View(viewModel);

  
        }
    }
}
