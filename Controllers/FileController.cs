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
        private async Task<FilesListViewModel> LoadAllFiles()
        {
            var viewModel = new FilesListViewModel();
            viewModel.Files = await db.File.ToListAsync();
            return viewModel;
        }
        public async Task<IActionResult> Index()
        {
            var ViewModel = await LoadAllFiles();
            ViewBag.Message = TempData["Message"];
            return View(ViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Upload(List<IFormFile> files, string description)
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
                    string outputFile = Path.Combine(basePath, Guid.NewGuid().ToString());
                 
                    EncryptFile.Encrypt(filePath, outputFile);
                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }
                    var fileModel = new FileModel
                    {
                        Name = fileName,
                        DateAdded = DateTime.Now,
                        FilePath = filePath,
                        CreatedBy = 1025,
                        FileTypeId = 1,
                        ContentType = file.ContentType,
                        User_File_GroupId= 1,
                        Size_in_Bytes = int.Parse(file.Length.ToString()),
                        Description = description,
                        FileName = outputFile,
                    };
                    db.File.Add(fileModel);
                    db.SaveChanges();
                   
                }
                 
            }
            TempData["Message"] = "File successfully uploaded to File System.";
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DownloadFile(int id)
        {

            var file = await db.File.Where(x => x.Id == id).FirstOrDefaultAsync();
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

            var file = await db.File.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (file != null)
            {

                if (System.IO.File.Exists(file.FileName))
                {
                    System.IO.File.Delete(file.FileName);
                }
                var extension = Path.GetExtension(file.FilePath);
                db.File.Remove(file);
                db.SaveChanges();
                TempData["Message"] = $"Removed {file.Name + extension} successfully from File System.";
            }
            return RedirectToAction("Index");
        }

    }
}
