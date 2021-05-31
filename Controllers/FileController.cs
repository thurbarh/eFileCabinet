    using DocumentServer.Data;
using DocumentServer.Models;
using DocumentServer.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentServer.Controllers
{
    public class FileController : Controller
    {
        private readonly ApplicationDbContext db;

        public FileController(ApplicationDbContext db)
        {
            this.db = db;
        }

       
        [HttpGet]
        public IActionResult GetAllFiles()
        {
            var model = db.Files.Select(x => new 

            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Size_in_Bytes = x.Size_in_Bytes,
                User = x.User.Fullname,
                DateAdded = x.DateAdded.ToString("D")
            }).ToList();
          return Json (new { data = model});
        }

        [HttpGet]
        public IActionResult GetAllUserFiles(int id)
        {
            var model = db.Files.Where(x=>x.UserId==id).Select(x => new
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Size_in_Bytes = x.Size_in_Bytes,
                DateAdded = x.DateAdded.ToString("D")
            }).ToList();
            return Json(new { data = model });
        }
        [HttpGet]
        public async Task<IActionResult> GetAllGroupFiles(int id)
            
        {
            var model = await db.Files.Where(x => x.UserGroupId == id).Select(x => new
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Name,
                Size_in_Bytes = x.Size_in_Bytes,
                _dateAdded = x.DateAdded.ToString("D")
            }).ToListAsync();            

            return Json(new { data = model });
        }

        public IActionResult UserGroupFiles(int id)
        {
            var model = new UserGroupViewModel
            {
                Id = id,
                Name = db.UserGroup.Where(x => x.Id == id).FirstOrDefault().Name
            };
            return View("UserGroup",model);
        }


        public IActionResult UserFiles(int id)
        {
            var model = new FileViewModel
            {
                UserId = id
            };
            return View("User",model);
        }

        public IActionResult Index()
        {
            var ViewModel = new FileViewModel();
            ViewBag.Message = TempData["Message"];
            return View(ViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Upload(List<IFormFile> files, string description, int userId)
        {
            foreach (var file in files)
            {
                var basePath = Path.Combine("C:\\DocumentServer\\Files\\");
                bool basePathExists = System.IO.Directory.Exists(basePath);
                if (!basePathExists) Directory.CreateDirectory(basePath);
                var fileName = Path.GetFileNameWithoutExtension(file.FileName);
                var filePath = Path.Combine(basePath, file.FileName);
                var extension = Path.GetExtension(file.FileName);
                if (!System.IO.File.Exists(filePath))
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    string newName = Guid.NewGuid().ToString() + ".sbs";
                    string outputFile = Path.Combine(basePath, newName);

                    EncryptFile.Encrypt(filePath, outputFile);
                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                    var fileModel = new Models.File
                    {
                        Name = fileName,
                        DateAdded = DateTime.Now,
                        FilePath = filePath,
                        UserId = userId,
                        FileTypeId = 1,
                        ContentType = file.ContentType,
                        UserGroupId = 1,
                        Size_in_Bytes = int.Parse(file.Length.ToString()),
                        Description = description,
                        FileName = outputFile,
                    };
                    db.Files.Add(fileModel);
                    db.SaveChanges();

                }

            }
            TempData["Message"] = $"File(s) successfully uploaded.";
            return RedirectToAction("Index");
        }
            [HttpPost]
        public async Task<IActionResult> UserUpload(List<IFormFile> files, string description, int userId )
        {
            foreach (var file in files)
            {
                var basePath = Path.Combine("C:\\DocumentServer\\Files\\");
                bool basePathExists = System.IO.Directory.Exists(basePath);
                if (!basePathExists) Directory.CreateDirectory(basePath);
                var fileName = Path.GetFileNameWithoutExtension(file.FileName);
                var filePath = Path.Combine(basePath, file.FileName);
                var extension = Path.GetExtension(file.FileName);
                if (!System.IO.File.Exists(filePath))
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                       await  file.CopyToAsync(stream);
                    }
                    string newName = Guid.NewGuid().ToString() + ".sbs";
                    string outputFile = Path.Combine(basePath, newName);
                 
                    EncryptFile.Encrypt(filePath, outputFile);
                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                    var fileModel = new Models.File
                    {
                        Name = fileName,
                        DateAdded = DateTime.Now,
                        FilePath = filePath,
                        UserId = userId,
                        FileTypeId = 1,
                        ContentType = file.ContentType,
                        UserGroupId = 1,
                        Size_in_Bytes = int.Parse(file.Length.ToString()),
                        Description = description,
                        FileName = outputFile,
                    };
                    db.Files.Add(fileModel);
                    db.SaveChanges();
                   
                }
                 
            }
            TempData["Message"] = $"File(s) successfully uploaded.";
            return RedirectToAction("UserFiles", new { id = userId });
        }
        public async Task<IActionResult> DownloadFile(int id)
        {

            var file = await db.Files.Where(x => x.Id == id).FirstOrDefaultAsync();
            EncryptFile.Decrypt(file.FileName, file.FilePath);
            var extension = Path.GetExtension(file.FilePath);
            if (file == null) return null;
            var memory = new MemoryStream();
            using (var stream = new FileStream(file.FilePath, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;

            EncryptFile.Encrypt(file.FileName, file.FilePath);
            if (System.IO.File.Exists(file.FilePath))
            {
                System.IO.File.Delete(file.FilePath);
            }
            return File(memory, file.ContentType, file.Name + extension);
          

        }
        public async Task<IActionResult> DeleteFile(int id)
        {

            var file = await db.Files.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (file != null)
            {

                if (System.IO.File.Exists(file.FileName))
                {
                    System.IO.File.Delete(file.FileName);
                }
                var extension = Path.GetExtension(file.FilePath);
                db.Files.Remove(file);
                db.SaveChanges();
                TempData["Message"] = $"Removed {file.Name + extension} successfully from File System.";
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteUserFile(int id)
        {

            var file = await db.Files.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (file != null)
            {

                if (System.IO.File.Exists(file.FileName))
                {
                    System.IO.File.Delete(file.FileName);
                }
                var extension = Path.GetExtension(file.FilePath);
                db.Files.Remove(file);
                db.SaveChanges();
                TempData["Message"] = $"Removed {file.Name + extension} successfully from File System.";
            }
            return RedirectToAction("UserFiles", new { id = file.UserId });

        }
        public async Task<IActionResult> DeleteUserGroupFile(int id)
        {

            var file = await db.Files.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (file != null)
            {

                if (System.IO.File.Exists(file.FileName))
                {
                    System.IO.File.Delete(file.FileName);
                }
                var extension = Path.GetExtension(file.FilePath);
                db.Files.Remove(file);
                db.SaveChanges();
                TempData["Message"] = $"Removed {file.Name + extension} successfully from File System.";
            }
            return RedirectToAction("UserGroupFiles", new { id = file.UserGroupId });

        }

    }
}
