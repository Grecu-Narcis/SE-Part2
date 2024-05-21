// <copyright file="BankAccountController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using Backend.Models;
using Iss.Repository;

namespace Iss.Service
{
    public class BankAccountService : InterfaceBankAccountService
    {
        private readonly AccountRepository accountRepository;

        public BankAccountService(AccountRepository repository)
        {
            accountRepository = repository;
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
            /*
            if (!BankAccount.Validate(updatedAccount))
            {
                throw new Exception("Invalid bank account data!");
            }
            else
            {
                accountRepository.BankAccount = updatedAccount;
            }
            */
            accountRepository.BankAccount = updatedAccount;
        }

        public BankAccount GetBankAccount()
        {
            return accountRepository.BankAccount;
        }
    }
}
