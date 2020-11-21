using AutoMapper;
using SafeShopping.API.Dtos;
using SafeShopping.Core.Entitiy.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SafeShopping.API.AutoMapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Account, AccountDto>();
            CreateMap<AccountDto, Account>();
        }
      
        
    }
}
