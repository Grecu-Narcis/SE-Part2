// <copyright file="LoginViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Backend.Login
{
    using Backend.Controllers;

    public class LoginViewModel
    {
        private readonly UserController userController;

        public LoginViewModel() => this.userController = new UserController();

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public bool AreUserCredentialsValidForLogin()
        {
            return this.userController.IsUserInTheLoginList(this.Username, this.Password, this.Email);
        }
    }
}
