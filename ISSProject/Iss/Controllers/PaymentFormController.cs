// <copyright file="PaymentFormController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Backend.Controllers
{
    using System;
    using System.Net;
    using System.Net.Mail;
    using System.Threading.Tasks;
    using Backend.Models;
    using Backend.Repositories;

    public class PaymentFormController : InterfacePaymentFormController
    {
        private readonly AccountRepository accountRepository;
        private readonly INterfaceProductRepository productRepository;

        public PaymentFormController(AccountRepository repositoryAccount, INterfaceProductRepository repositoryProduct)
        {
            this.accountRepository = repositoryAccount;
            this.productRepository = repositoryProduct;
        }

        public Task SendPaymentConfirmationMailAsync()
        {
            var sender = "osvathrobert03@gmail.com";
            var receiver = this.accountRepository.BankAccount.Email;
            var password = "daes ndml ukpj qvuj";

            var product = this.productRepository.Product;
            var subject = "Running tests im sorry";

            // var subject = "Payment Confirmation For " + product.Name;
            var message = "Description: " + product.Description + "\nPrice: " + product.Price;

            var client = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(sender, password),
                EnableSsl = true,
            };

            if (string.IsNullOrWhiteSpace(receiver))
            {
                throw new InvalidOperationException("Receiver email cannot be null or empty.");
            }

            var mail = new MailMessage(
                from: sender,
                to: receiver,
                subject: subject,
                body: message);
            return client.SendMailAsync(mail);
        }

        public ProductMock GetProduct()
        {
            return this.productRepository.Product;
        }
    }
}
