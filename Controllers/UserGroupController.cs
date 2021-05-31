using DocumentServer.Data;
using DocumentServer.Models;
using DocumentServer.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentServer.Controllers
{
    public class UserGroupController : Controller
    {
        private readonly ApplicationDbContext db;

        public UserGroupController(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUserGroups()
        {

            var model = await db.UserGroup.Where(x => x.IsActive == 'Y').Select(x => new

            {
                Id = x.Id,
                Name = x.Name

            }).ToListAsync();

            return Json(new { data = model });
        }

        public IActionResult Index()
        {
            var viewModel = new UserGroupViewModel();
            ViewBag.Message = TempData["Message"];
            return View(viewModel);
        }
        public async Task<IActionResult> CreateUserGroup(UserGroupViewModel newUserGroup)
        {
            if (newUserGroup != null)
            {
                var user = new UserGroup()
                {
                    Name = newUserGroup.Name,
                    IsActive = 'Y'
                };

                await db.AddAsync(user);

                if (await db.SaveChangesAsync() > 0)
                {
                    TempData["Message"] = $"{newUserGroup.Name} successfully added.";
                }
                else
                {
                    TempData["Message"] = "Something went wrong.";

                }
            }
            else
            {
                TempData["Message"] = "Invalid Request";

            }
            return RedirectToAction("Index");



        }
        public async Task<IActionResult> DeleteUserGroup(int id)
        {

            var userGroup = await db.UserGroup.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (userGroup != null)
            {
                userGroup.IsActive = 'N';
                var users = await db.Users.Where(x => x.UserGroupId == id).ToListAsync();
                foreach (var user in users)
                {
                    user.IsActive = 'N';
                    var userFiles = await db.Files.Where(x => x.UserId == user.Id).ToListAsync();
                    foreach (var file in userFiles)
                    {
                        file.Comment += $"This file belongs to a deleted Department ({userGroup.Name})')";
                    }
                }
                if (db.SaveChanges() > 0)
                {
                    TempData["Message"] = $"{userGroup.Name} successfully deleted.";
                }
                else
                {
                    TempData["Message"] = "Something went wrong.";

                }
            }
            else
            {
                TempData["Message"] = "Invalid Request";

            }
            return RedirectToAction("Index");

        }
    }
}
