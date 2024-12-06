using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Data;
using DomainAccessLayer.Entities;
using DomainAccessLayer.RepoInterfaces;

namespace DataAccessLayer.Repository
{
    public class AccountRepo : IAccountEntity
    {
        private readonly AppDbContext db;

        public AccountRepo(AppDbContext db)
        {
            this.db = db;
        }
        public async Task<int> CheckBalace(int id)
        {
            try
            {
                var balance = await db.AccData.FindAsync(id);
                return balance.AccountId;
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        public Task<bool> Deposit(AccountEntity obj)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Withdraw(AccountEntity obj)
        {
            throw new System.NotImplementedException();
        }
    }
}