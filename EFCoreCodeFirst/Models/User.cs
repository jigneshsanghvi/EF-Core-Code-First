﻿using System.ComponentModel.DataAnnotations;

namespace EFCoreCodeFirst.Models
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }
        public string Username { get; set; }

        public string? Email { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }
        public string Password { get; set; }    

        //public virtual Role Role { get; set; }
        public string Role { get; set; }
    }
}
