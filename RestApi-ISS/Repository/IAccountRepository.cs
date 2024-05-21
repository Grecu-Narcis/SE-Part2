using Backend.Models;

namespace Iss.Repository
{
    internal interface IAccountRepository
    {
        BankAccount BankAccount { get; set; }
    }
}
