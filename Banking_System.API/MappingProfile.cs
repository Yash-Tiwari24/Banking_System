using AutoMapper;
using Banking_System.Model.Model;
using Banking_System.Model.View_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Banking_System.API
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Users, GetUser>();
            CreateMap<RegisterUsersDto, Users>();
            CreateMap<UpdateUserDto, Users>();
            CreateMap<RegisterNewAccountDto, Account>();
            CreateMap<UpdateAccount, Account>();
            
        }
    }
}
