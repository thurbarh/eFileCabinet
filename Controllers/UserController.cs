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
                RoleId = x.RoleId,
                Username = x.Username,
                Password = x.Password,
                FullName = x.FullName,
               
                User_File_GroupId = x.User_File_GroupId
                


            }).ToListAsync();
            return viewModel;

        }
        public async Task<IActionResult> IndexAsync()
        {
            var viewModel = await LoadAllUsers();
            ViewBag.Message = TempData["Message"];
            return View(viewModel);

  
        }
    }
}
