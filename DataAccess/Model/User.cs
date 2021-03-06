﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Model
{
    public class User
    {
        public int ID { get; set; }

        [Required, MaxLength(40), Index(IsUnique = true)]
        public string Username { get; set; }

        [Required, MaxLength(100)]
        public string Password { get; set; }

        [Required, MaxLength(100)]
        public string Email { get; set; }
    }
}