using System.Threading.Tasks;
using DomainAccessLayer.Entities;

namespace DomainAccessLayer.RepoInterfaces
{
    public interface IAccountEntity
    {
        Task<bool> Deposit(AccountEntity obj);
        Task<bool> Withdraw(AccountEntity obj);
        Task<int> CheckBalace(int id);
    }
}