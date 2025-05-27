using AutoMapper;
using ResturantDelivery.Dtos;
using ResturantDelivery.Models;

namespace ResturantDelivery.MapperConfigs
{
    public class UserProfile:Profile 
    {
        public UserProfile()
        {
            CreateMap<RegisterDto, User > ()
                 .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());
        }
    }
}
