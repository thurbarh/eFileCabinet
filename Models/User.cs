﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentServer.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public int UserGroupId { get; set; }


        public virtual ICollection<File> Files { get; set; }
        public virtual UserGroup UserGroup { get; set; }
    }

    
}
