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
        }
    }
}
