using System.Collections.Generic;

namespace DocumentServer.Models
{
    public class UserGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public char IsActive { get; set; }

        public virtual ICollection<File> Files { get; set; }
        public virtual ICollection<GroupResource> GroupResource { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}