using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentServer.Models.ViewModels
{
    public class UserViewModel
    {
        [Required]
        public int Id { get; set; }


        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public int UserGroupId { get; set; }

        public string UserGroupName { get; set; }


    }
}
