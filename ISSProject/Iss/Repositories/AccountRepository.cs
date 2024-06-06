// <copyright file="AccountRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Backend.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using Backend.Models;
    using Backend.Services;
    using Iss.Database;
    using Microsoft.EntityFrameworkCore;

    public class AccountRepository : IAccountRepository
    {
        private DatabaseConnection databaseConnection = new DatabaseConnection();
        private SqlDataAdapter adapter = new SqlDataAdapter();
        private DatabaseContext databaseContext = new DatabaseContext();
        private BankAccount bankAccount = new BankAccount();
        private DataEncryptionService encryptionService = new DataEncryptionService();

        private string? emailKey;
        private string? nameKey;
        private string? surnameKey;
        private string? phoneNumberKey;
        private string? countyKey;
        private string? cityKey;
        private string? addressKey;
        private string? numberKey;
        private string? holderNameKey;
        private string? expirationDateKey;

        public AccountRepository()
        {
        }

        public AccountRepository(BankAccount bankAccount)
        {
            this.bankAccount = bankAccount;
        }

        public BankAccount GetBankAccount(string email)
        {
            var encryptedEmail = encryptionService.Encrypt(email)["data"];
            bankAccount = databaseContext.BankAccount
                .AsNoTracking()
                .FirstOrDefault(account => account.Email == encryptedEmail);

            if (bankAccount == null)
            {
                throw new Exception("Bank account not found");
            }

            return DecryptBankAccount(bankAccount);
        }
        public BankAccount GetBankAccount()
        {
            try
            {
                // bankAccount = databaseContext.BankAccount.AsNoTracking().FirstOrDefault();
                bankAccount = databaseContext.BankAccount
                .AsNoTracking()
                .FirstOrDefault(account => account.Email == "osvathrobertlevente@gmail.com");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            if (bankAccount == null)
            {
                throw new Exception("Bank account not found");
            }

            // return DecryptBankAccount(bankAccount);
            return bankAccount;
        }

        public void AddBankAccount(BankAccount account)
        {
            var encryptedAccount = EncryptBankAccount(account);
            // databaseContext.BankAccount.Add(encryptedAccount);
            databaseContext.BankAccount.Add(account);
            databaseContext.SaveChanges();
        }

        public void EditBankAccount(BankAccount updatedAccount)
        {
            var encryptedAccount = EncryptBankAccount(updatedAccount);
            databaseContext.BankAccount.Update(encryptedAccount);
            databaseContext.SaveChanges();
        }

        private BankAccount EncryptBankAccount(BankAccount account)
        {
            var encryptedAccount = new BankAccount
            {
                Email = encryptionService.Encrypt(account.Email!)["data"],
                Name = encryptionService.Encrypt(account.Name!)["data"],
                Surname = encryptionService.Encrypt(account.Surname!)["data"],
                PhoneNumber = encryptionService.Encrypt(account.PhoneNumber!)["data"],
                County = encryptionService.Encrypt(account.County!)["data"],
                City = encryptionService.Encrypt(account.City!)["data"],
                Address = encryptionService.Encrypt(account.Address!)["data"],
                Number = encryptionService.Encrypt(account.Number!)["data"],
                HolderName = encryptionService.Encrypt(account.HolderName!)["data"],
                ExpiryDate = encryptionService.Encrypt(account.ExpiryDate!)["data"]
            };

            emailKey = encryptionService.Encrypt(account.Email!)["key"];
            nameKey = encryptionService.Encrypt(account.Name!)["key"];
            surnameKey = encryptionService.Encrypt(account.Surname!)["key"];
            phoneNumberKey = encryptionService.Encrypt(account.PhoneNumber!)["key"];
            countyKey = encryptionService.Encrypt(account.County!)["key"];
            cityKey = encryptionService.Encrypt(account.City!)["key"];
            addressKey = encryptionService.Encrypt(account.Address!)["key"];
            numberKey = encryptionService.Encrypt(account.Number!)["key"];
            holderNameKey = encryptionService.Encrypt(account.HolderName!)["key"];
            expirationDateKey = encryptionService.Encrypt(account.ExpiryDate!)["key"];

            return encryptedAccount;
        }

        private BankAccount DecryptBankAccount(BankAccount encryptedAccount)
        {
            return new BankAccount
            {
                Email = encryptionService.Decrypt(encryptedAccount.Email!, emailKey!),
                Name = encryptionService.Decrypt(encryptedAccount.Name!, nameKey!),
                Surname = encryptionService.Decrypt(encryptedAccount.Surname!, surnameKey!),
                PhoneNumber = encryptionService.Decrypt(encryptedAccount.PhoneNumber!, phoneNumberKey!),
                County = encryptionService.Decrypt(encryptedAccount.County!, countyKey!),
                City = encryptionService.Decrypt(encryptedAccount.City!, cityKey!),
                Address = encryptionService.Decrypt(encryptedAccount.Address!, addressKey!),
                Number = encryptionService.Decrypt(encryptedAccount.Number!, numberKey!),
                HolderName = encryptionService.Decrypt(encryptedAccount.HolderName!, holderNameKey!),
                ExpiryDate = encryptionService.Decrypt(encryptedAccount.ExpiryDate!, expirationDateKey!)
            };
        }
    }
}