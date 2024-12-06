using AutoMapper;
using BusinessAccessLayer.DTOs;
using DomainAccessLayer.Entities;

namespace BusinessAccessLayer.Helper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
           CreateMap<AccountInfoDTO, AccountEntity>();
        }
    }
}