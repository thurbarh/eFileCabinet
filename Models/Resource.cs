using System.Collections.Generic;

namespace DocumentServer.Models
{
    public class Resource
    {
        public int Id { get; set; }
        public int Max_File_Size { get; set; }
        public string Permissions { get; set; }
        public string Allowed_File_Types { get; set; }

        public virtual ICollection<GroupResource> GroupResource { get; set; }
    }
}