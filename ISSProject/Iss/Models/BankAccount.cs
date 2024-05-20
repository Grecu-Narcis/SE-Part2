// <copyright file="BankAccount.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Backend.Models
{
    using System.ComponentModel.DataAnnotations;

    public class BankAccount
    {
        public string? Email { get; set; }

        public string? Name { get; set; }

        public string? Surname { get; set; }

        public string? PhoneNumber { get; set; }

        public string? County { get; set; }

        public string? City { get; set; }

        public string? Address { get; set; }

        public string? Number { get; set; }

        public string? HolderName { get; set; }

        public string? ExpiryDate { get; set; }

        public static bool Validate(BankAccount bankAccount)
        {
            // validate email
            var emailAttribute = new EmailAddressAttribute();
            if (bankAccount.Email == null || !emailAttribute.IsValid(bankAccount.Email))
            {
                return false;
            }

            // validate name
            if (bankAccount.Name == null || bankAccount.Name.Length < 2)
            {
                return false;
            }

            // validate surname
            if (bankAccount.Surname == null || bankAccount.Surname.Length < 2)
            {
                return false;
            }

            // validate phone number
            if (bankAccount.PhoneNumber == null)
            {
                return false;
            }

            if (bankAccount.PhoneNumber.Length < 9)
            {
                foreach (char currentCharacter in bankAccount.PhoneNumber)
                {
                    if (!char.IsDigit(currentCharacter))
                    {
                        return false;
                    }
                }
            }

            // validate county
            if (bankAccount.County == null || bankAccount.County.Length < 2)
            {
                return false;
            }

            // validate city
            if (bankAccount.City == null || bankAccount.City.Length < 2)
            {
                return false;
            }

            // validate address
            if (bankAccount.Address == null || bankAccount.Address.Length < 2)
            {
                return false;
            }

            // validate number
            if (bankAccount.Number == null)
            {
                return false;
            }

            if (bankAccount.Number.Length < 16)
            {
                foreach (char currentCharacter in bankAccount.Number)
                {
                    if (!char.IsDigit(currentCharacter))
                    {
                        return false;
                    }
                }
            }

            // validate holder name
            if (bankAccount.HolderName == null || bankAccount.HolderName.Length < 2)
            {
                return false;
            }

            // validate expiry date
            if (bankAccount.ExpiryDate == null || bankAccount.ExpiryDate.Length < 5)
            {
                return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = (hash * 23) + (Email?.GetHashCode() ?? 0);
                hash = (hash * 23) + (Name?.GetHashCode() ?? 0);
                hash = (hash * 23) + (Surname?.GetHashCode() ?? 0);
                return hash;
            }
        }

        public override bool Equals(object? obj)
        {
            if (obj is BankAccount other)
            {
                return this.Email == other.Email &&
                       this.Name == other.Name &&
                       this.Surname == other.Surname &&
                       this.PhoneNumber == other.PhoneNumber &&
                       this.County == other.County &&
                       this.City == other.City &&
                       this.Address == other.Address &&
                       this.Number == other.Number &&
                       this.HolderName == other.HolderName &&
                       this.ExpiryDate == other.ExpiryDate;
            }

            return false;
        }
    }
}
