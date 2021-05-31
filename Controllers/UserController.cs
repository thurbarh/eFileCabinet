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
    public class UserController : Controller
    {
        private readonly ApplicationDbContext db;

        public UserController(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {



            var model = await db.Users.Where(x => x.IsActive == 'Y').Select(x => new

            {
                Id = x.Id,
                Username = x.Username,
                Password = x.Password,
                Fullname = x.Fullname,
               Department = x.UserGroup.Name
            }).ToListAsync();



            return Json(new { data = model });
        }
        public async Task<IActionResult> GetAllUserGroupMembers(int id)
        {



            var model = await db.Users.Where(x => x.IsActive == 'Y').Where(x=>x.UserGroupId==id).Select(x => new

            {
                Id = x.Id,
                Username = x.Username,
                Password = x.Password,
                Fullname = x.Fullname,
                Department = x.UserGroup.Name
            }).ToListAsync();



            return Json(new { data = model });
        }
        public async Task<IActionResult> Index()
        {
            var viewModel = new UserViewModel();
            List<UserGroup> Departments = await db.UserGroup.ToListAsync();
            Departments.Insert(0, new UserGroup { Id = 0, Name = "Select" });
            ViewBag.DeparmentList = Departments;

            ViewBag.Message = TempData["Message"];
            return View(viewModel);


        }

        public IActionResult UserGroupMembers(int id)
        {
            var model = new UserViewModel
            {
                UserGroupId = id,
                UserGroupName = db.UserGroup.Where(x => x.Id == id).FirstOrDefault().Name
            };
            return View("UserGroup", model);
        }

        public async Task<IActionResult> CreateUser(UserViewModel newUser)
        {
            if (newUser != null)
            {
                var user = new User()
                {
                    Fullname = newUser.FullName,
                    Username = newUser.Username,
                    Password = newUser.Password,
                    UserGroupId = newUser.UserGroupId,
                    IsActive = 'Y'
                };

                await db.AddAsync(user);

                if (await db.SaveChangesAsync() > 0)
                {
                    TempData["Message"] = $"{newUser.FullName} successfully added.";
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
        public async Task<IActionResult> CreateGroupUser(UserViewModel newUser)
        {
            if (newUser != null)
            {
                var user = new User()
                {
                    Fullname = newUser.FullName,
                    Username = newUser.Username,
                    Password = newUser.Password,
                    UserGroupId = newUser.UserGroupId,
                    IsActive = 'Y'
                };

                await db.AddAsync(user);

                if (await db.SaveChangesAsync() > 0)
                {
                    TempData["Message"] = $"{newUser.FullName} successfully added.";
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
            return RedirectToAction("UserGroupMembers",new { id = newUser.UserGroupId});



        }

        public async Task<IActionResult> DeleteUser(int id)
        {

            var user = await db.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (user != null)
            {
                user.IsActive = 'N';
                var userFiles = await db.Files.Where(x => x.UserId == id).ToListAsync();
                foreach (var file in userFiles)
                {
                    file.Comment = $"This file was Created by already Deleted User('{user.Fullname}')";
                }
                if (db.SaveChanges() > 0)
                {
                    TempData["Message"] = $"{user.Fullname} successfully deleted.";
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
        public async Task<IActionResult> DeleteGroupUser(int id)
        {

            var user = await db.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (user != null)
            {
                user.IsActive = 'N';
                var userFiles = await db.Files.Where(x => x.UserId == id).ToListAsync();
                foreach (var file in userFiles)
                {
                    file.Comment = $"This file was Created by already Deleted User('{user.Fullname}')";
                }
                if (db.SaveChanges() > 0)
                {
                    TempData["Message"] = $"{user.Fullname} successfully deleted.";
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
            return RedirectToAction("UserGroupMembers", new { id = user.UserGroupId });

        }
    }
 }


