using System.Threading.Tasks;
using BusinessAccessLayer.DTOs;

namespace BusinessAccessLayer.Interfaces
{
    public interface IAccount
    {
        Task<bool> Deposit(AccountInfoDTO obj);
        Task<bool> Withdraw(AccountInfoDTO obj);
        Task<int> CheckBalace(int id);
    }
}