using AutoMapper;
using ResturantDelivery.Dtos;
using ResturantDelivery.Models;

namespace ResturantDelivery.MapperConfigs
{
    public class CustomerConfig:Profile
    {
        public CustomerConfig()
        {
            CreateMap<CustomerDto, Customer>();
            CreateMap<Customer, CustomerDto>();

            // register :
            CreateMap<CustomerRegisterDto, Customer>()
           .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());
            // login
            CreateMap<CustomerLoginDto, Customer>()
          .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());

        }
    }
}
