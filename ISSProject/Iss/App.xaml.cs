// <copyright file="App.xaml.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Frontend
{
    using System;
    using System.Windows;
    using Backend.Controllers;
    using Backend.Models;
    using Backend.Repositories;
    using Iss;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Interaction logic for App.xaml.
    /// </summary>
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var services = new ServiceCollection();

            var bankAccount = new BankAccount
            {
                Email = "osvathrobertlevente@gmail.com",
                Name = "Name",
                Surname = "Surname",
                PhoneNumber = "0740123456",
                County = "Cluj",
                City = "Cluj-Napoca",
                Address = "Str. SomeStreet, Nr. 1",
                Number = "123456789",
                HolderName = "Name Surname",
                ExpiryDate = "12/23",
            };
            // services.AddSingleton(bankAccount);
            var mockProduct = new ProductMock
            {
                Name = "Product",
                Description = "Description",
                Price = "100",
                Image = "doggo.png",
            };
            services.AddSingleton(mockProduct);

            var accountRepository = new AccountRepository();
            accountRepository.AddBankAccount(bankAccount);
            services.AddSingleton(accountRepository);

            var productRepository = new ProductRepository(mockProduct);
            services.AddSingleton(productRepository);

            var bankAccountController = new BankAccountController(accountRepository);
            services.AddSingleton(bankAccountController);

            var paymentFormController = new PaymentFormController(accountRepository, productRepository);
            services.AddSingleton(paymentFormController);

            ServiceProvider = services.BuildServiceProvider();

            /*LoginWindow mainWindow = new ();
            mainWindow.Show();

            LoginInfluencer influencerWindow = new ();
            influencerWindow.Show();*/
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
