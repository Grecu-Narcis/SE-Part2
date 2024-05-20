using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Models;
using Backend.Repositories;

namespace Backend.Controllers
{
    public interface InterfaceBankAccountController
    {
        void UpdateBankAccount(
            string name,
            string surname,
            string email,
            string phoneNumber,
            string county,
            string city,
            string address,
            string number,
            string holderName,
            string expiryDate);

        BankAccount GetBankAccount();
    }
}