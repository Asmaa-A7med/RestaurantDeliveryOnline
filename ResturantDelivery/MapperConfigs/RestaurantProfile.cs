using AutoMapper;
using ResturantDelivery.Dtos;
using ResturantDelivery.Models;

namespace ResturantDelivery.MapperConfigs
{
    public class RestaurantProfile:Profile
    {
        public RestaurantProfile() {

            CreateMap<Restaurant, ResturantDto>();
            CreateMap<MenuItem, MenuItemDto>();

            CreateMap<Restaurant, SearchRestaurantDto>()
    .ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.City.Name));


        }
    }
}
