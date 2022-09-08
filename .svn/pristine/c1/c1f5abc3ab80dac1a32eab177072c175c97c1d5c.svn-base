using AutoMapper;
using EMarket.Entities;
using EMarket.Entities.Entities;
using EMarket.Entities.LoginContext;
using EMarket.Models;
using EMarketDTO;
using Microsoft.AspNetCore.Identity;

namespace EMarket.Mapper
{
    public class DataMapper : Profile
    {
        public DataMapper()
        {
            ConfigureMappings();
        }

        private void ConfigureMappings()
        {         
           // CreateMap<Customer, CustomerDto>().ReverseMap();
     
            CreateMap<IdentityUser, UserDto>().ReverseMap();
            CreateMap<UserDetails, UserDetailsDto>().ReverseMap();
            CreateMap<Master_LocationDMO, Master_LocationDTO>().ReverseMap();
         


        }
    }
}
