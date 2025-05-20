using AutoMapper;
using ResturantDelivery.Dtos;
using ResturantDelivery.Models;

namespace ResturantDelivery.MapperConfigs
{
    public class MenueProfile:Profile
    {
        public MenueProfile()
        {
            CreateMap<MenuItem, MenuItemDto>();

        }
    }
}
