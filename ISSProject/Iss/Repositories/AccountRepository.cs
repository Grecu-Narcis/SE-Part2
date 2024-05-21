// <copyright file="AccountRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Backend.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Reflection.Metadata.Ecma335;
    using System.Security.Principal;
    using System.Text;
    using System.Threading.Tasks;
    using Backend.Models;
    using Backend.Services;

    public class AccountRepository : IAccountRepository
    {
        private DatabaseConnection databaseConnection = new DatabaseConnection();
        private readonly SqlDataAdapter adapter = new SqlDataAdapter();
        private readonly DataEncryptionService encryptionService = new DataEncryptionService();
        private BankAccount bankAccount = new BankAccount();
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

        public AccountRepository(BankAccount account)
        {
            BankAccount = account ?? throw new ArgumentNullException(nameof(account));
        }

        public AccountRepository(BankAccount account, DataEncryptionService encryptionService)
        {
            this.encryptionService = encryptionService ?? throw new ArgumentNullException(nameof(encryptionService));
            BankAccount = account ?? throw new ArgumentNullException(nameof(account));
        }

        public BankAccount BankAccount
        {
            get
            {
                string? decryptedEmail = encryptionService.Decrypt(this.bankAccount.Email!, emailKey!);
                string? decryptedName = encryptionService.Decrypt(this.bankAccount.Name!, nameKey!);
                string? decryptedSurname = encryptionService.Decrypt(this.bankAccount.Surname!, surnameKey!);
                string? decryptedPhoneNumber = encryptionService.Decrypt(this.bankAccount.PhoneNumber!, phoneNumberKey!);
                string? decryptedCounty = encryptionService.Decrypt(this.bankAccount.County!, countyKey!);
                string? decryptedCity = encryptionService.Decrypt(this.bankAccount.City!, cityKey!);
                string? decryptedAddress = encryptionService.Decrypt(this.bankAccount.Address!, addressKey!);
                string? decryptedNumber = encryptionService.Decrypt(this.bankAccount.Number!, numberKey!);
                string? decryptedHolderName = encryptionService.Decrypt(this.bankAccount.HolderName!, holderNameKey!);
                string? decryptedExpiryDate = encryptionService.Decrypt(this.bankAccount.ExpiryDate!, expirationDateKey!);

                return new BankAccount
                {
                    Email = decryptedEmail,
                    Name = decryptedName,
                    Surname = decryptedSurname,
                    PhoneNumber = decryptedPhoneNumber,
                    County = decryptedCounty,
                    City = decryptedCity,
                    Address = decryptedAddress,
                    Number = decryptedNumber,
                    HolderName = decryptedHolderName,
                    ExpiryDate = decryptedExpiryDate,
                };
            }

            set
            {
                Dictionary<string, string> encryptedEmailKeyValuePair = encryptionService.Encrypt(value.Email!);
                string encryptedEmail = encryptedEmailKeyValuePair["data"];
                emailKey = encryptedEmailKeyValuePair["key"];
                Dictionary<string, string> encryptedNameKeyValuePair = encryptionService.Encrypt(value.Name!);
                string encryptedName = encryptedNameKeyValuePair["data"];
                nameKey = encryptedNameKeyValuePair["key"];
                Dictionary<string, string> encryptedSurnameKeyValuePair = encryptionService.Encrypt(value.Surname!);
                string encryptedSurname = encryptedSurnameKeyValuePair["data"];
                surnameKey = encryptedSurnameKeyValuePair["key"];
                Dictionary<string, string> encryptedPhoneNumberKeyValuePair = encryptionService.Encrypt(value.PhoneNumber!);
                string encryptedPhoneNumber = encryptedPhoneNumberKeyValuePair["data"];
                phoneNumberKey = encryptedPhoneNumberKeyValuePair["key"];
                Dictionary<string, string> encryptedCountyKeyValuePair = encryptionService.Encrypt(value.County!);
                string encryptedCounty = encryptedCountyKeyValuePair["data"];
                countyKey = encryptedCountyKeyValuePair["key"];
                Dictionary<string, string> encryptedCityKeyValuePair = encryptionService.Encrypt(value.City!);
                string encryptedCity = encryptedCityKeyValuePair["data"];
                cityKey = encryptedCityKeyValuePair["key"];
                Dictionary<string, string> encryptedAddressKeyValuePair = encryptionService.Encrypt(value.Address!);
                string encryptedAddress = encryptedAddressKeyValuePair["data"];
                addressKey = encryptedAddressKeyValuePair["key"];
                Dictionary<string, string> encryptedNumberKeyValuePair = encryptionService.Encrypt(value.Number!);
                string encryptedNumber = encryptedNumberKeyValuePair["data"];
                numberKey = encryptedNumberKeyValuePair["key"];
                Dictionary<string, string> encryptedHolderNameKeyValuePair = encryptionService.Encrypt(value.HolderName!);
                string encryptedHolderName = encryptedHolderNameKeyValuePair["data"];
                holderNameKey = encryptedHolderNameKeyValuePair["key"];
                Dictionary<string, string> encryptedExpiryDateKeyValuePair = encryptionService.Encrypt(value.ExpiryDate!);
                string encryptedExpiryDate = encryptedExpiryDateKeyValuePair["data"];
                expirationDateKey = encryptedExpiryDateKeyValuePair["key"];
                bankAccount = new BankAccount
                {
                    Email = encryptedEmail,
                    Name = encryptedName,
                    Surname = encryptedSurname,
                    PhoneNumber = encryptedPhoneNumber,
                    County = encryptedCounty,
                    City = encryptedCity,
                    Address = encryptedAddress,
                    Number = encryptedNumber,
                    HolderName = encryptedHolderName,
                    ExpiryDate = encryptedExpiryDate,
                };
            }
        }
    }
}