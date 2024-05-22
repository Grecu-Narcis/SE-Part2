using Backend.Models;

namespace Backend.Repositories
{
    internal interface IAccountRepository
    {
        public BankAccount GetBankAccount();
        public void AddBankAccount(BankAccount account);
        public void EditBankAccount(BankAccount updatedAccount);
    }
}