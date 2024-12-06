using System.Threading.Tasks;
using AutoMapper;
using BusinessAccessLayer.DTOs;
using BusinessAccessLayer.Interfaces;
using DomainAccessLayer.RepoInterfaces;

namespace BusinessAccessLayer.Services
{
    public class AccountService : IAccount
    {
        private readonly IAccountEntity accEntity;
        private readonly IMapper mapper;

        public AccountService(IAccountEntity accEntity, IMapper mapper)
        {
            this.accEntity = accEntity;
            this.mapper = mapper;
        }
        public async Task<int> CheckBalace(int id)
        {
            return await accEntity.CheckBalace(id);
        }

        public Task<bool> Deposit(AccountInfoDTO obj)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Withdraw(AccountInfoDTO obj)
        {
            throw new System.NotImplementedException();
        }
    }
}