using System.Collections.Generic;

namespace DocumentServer.Models
{
    public class FileType
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<File> Files { get; set; }
    }
}