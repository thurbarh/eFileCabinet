using DocumentServer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentServer.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<File> Files { get; set; }
        public DbSet<FileType> FileTypes { get; set; }
        public DbSet<GroupResource> Group_Resource { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserGroup> User_Group { get; set; }
    }
}
 