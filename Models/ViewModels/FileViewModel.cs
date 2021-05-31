using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentServer.Models.ViewModels
{
    public class FileViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime DateAdded { get; set; }
        [Required]
        public string FilePath { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int FileTypeId { get; set; }
        [Required]
        public int UserGroupId { get; set; }
        [Required]
        public int Size_in_Bytes { get; set; }

        public string Description { get; set; }
        [Required]
        public string FileName { get; set; }

        public DateTime LastEditDate { get; set; }
        public int EditedBy { get; set; }

        public string _dateAdded { get; set; }
        public string Comment { get; set; }
    }
}
