// <copyright file="UserController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Backend.Controllers
{
    using Backend.Models;

    public class UserController
    {
        private readonly List<User> listOfUsersWhoCanLogin;

        public UserController()
        {
            this.listOfUsersWhoCanLogin = new List<User>
            {
                new () { Username = "user1", Password = "pass1", Email = "user1@example.com" },
                new () { Username = "user2", Password = "pass2", Email = "user2@example.com" },
            };
        }

        public bool IsUserInTheLoginList(string username, string password, string email)
        {
            return this.listOfUsersWhoCanLogin.Any(user => user.Username == username && user.Email == email && user.Password == password);
        }
    }
}
