﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetCore6Test.Entities.Auth
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string FirstName { get; set; } = "";

        public string LastName { get; set; } = "";
        
        public string Username { get; set; } = "";

        public string Email { get; set; } = "";

        public byte[]? PasswordHash { get; set; } = null;

        public byte[]? PasswordSalt { get; set; } = null;

        public bool IsAdmin { get; set; } = false;

        public string GetFullName()
        {
            return FirstName + LastName;
        }

    }
}
