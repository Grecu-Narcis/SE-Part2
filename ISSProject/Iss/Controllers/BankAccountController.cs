// <copyright file="BankAccountController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using Backend.Models;
using Backend.Repositories;

namespace Backend.Controllers
{
    public class BankAccountController : InterfaceBankAccountController
    {
        private readonly AccountRepository accountRepository;

        public BankAccountController(AccountRepository repository)
        {
            this.accountRepository = repository;
        }

        public void UpdateBankAccount(string name, string surname, string email, string phoneNumber, string county, string city, string address, string number, string holderName, string expiryDate)
        {
            BankAccount updatedAccount = new ()
            {
                Email = email,
                Name = name,
                Surname = surname,
                PhoneNumber = phoneNumber,
                County = county,
                City = city,
                Address = address,
                Number = number,
                HolderName = holderName,
                ExpiryDate = expiryDate,
            };
            if (!BankAccount.Validate(updatedAccount))
            {
                throw new Exception("Invalid bank account data!");
            }
            else
            {
                this.accountRepository.BankAccount = updatedAccount;
            }
        }

        public BankAccount GetBankAccount()
        {
            return this.accountRepository.BankAccount;
        }
    }
}
