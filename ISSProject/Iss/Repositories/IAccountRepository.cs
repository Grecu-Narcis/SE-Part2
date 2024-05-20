using Backend.Models;

namespace Backend.Repositories
{
    internal interface IAccountRepository
    {
        BankAccount BankAccount { get; set; }
    }
}
