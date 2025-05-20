using AutoMapper;
using ResturantDelivery.Dtos;
using ResturantDelivery.Models;

namespace ResturantDelivery.MapperConfigs
{
    public class citiesProfile:Profile
    {

        public citiesProfile()
        {
            CreateMap<City, citiesDto>();
        }
    }
}
