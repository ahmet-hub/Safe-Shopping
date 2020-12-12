using AutoMapper;
using SafeShopping.API.Resource;
using SafeShopping.Core.Entitiy.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SafeShopping.API.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterResource, User>();
            CreateMap<User, RegisterResource>();
        }


    }
}
