using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentServer.Models
{
    public class File
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateAdded { get; set; }
        public string FilePath { get; set; }
        public int CreatedBy { get; set; }
        public int FileTypeId { get; set; }
        public int User_File_GroupId { get; set; }
        public int Size_in_Bytes { get; set; }
        public string Description { get; set; }
        public string ContentType { get; set; }
        public string FileName { get; set; }
        public DateTime LastEditDate { get; set; }
        public int EditedBy { get; set; }
        public string Comment { get; set; }


    }
}
