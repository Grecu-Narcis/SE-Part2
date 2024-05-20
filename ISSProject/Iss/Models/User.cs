// <copyright file="User.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Backend.Models
{
    public class User
    {
        public User()
        {
            this.Username = string.Empty;
            this.Password = string.Empty;
            this.Email = string.Empty;
        }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }
    }
}
