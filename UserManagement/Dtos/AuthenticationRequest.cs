﻿using System.ComponentModel.DataAnnotations;

namespace UserManagement.Dtos
{
    public class AuthenticationRequest
    {
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
