using AutoMapper;
using ResturantDelivery.Data;
using ResturantDelivery.Dtos;

namespace ResturantDelivery.Services
{
    public class ResturantService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ResturantService(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // get all resturants :
        public async Task<List<ResturantDto>> GetAllRestaurantsAsync()
        {
            var restaurants = await _unitOfWork.Restaurants.GetAllWithCityAsync();

            return _mapper.Map<List<ResturantDto>>(restaurants);
        }

        // search for resturant :
        public async Task<List<SearchRestaurantDto>> SearchRestaurantsAsync(string? name, string? cityName)
        {
            var restaurants = await _unitOfWork.Restaurants.SearchRestaurantsAsync(name, cityName);
            return _mapper.Map<List<SearchRestaurantDto>>(restaurants);
        }

        // get menue items based on resturant id ;
        public async Task<List<MenuItemDto>> GetMenuByRestaurantIdAsync(int restaurantId)
        {
            var menuItems = await _unitOfWork.MenuItems.GetMenuByRestaurantIdAsync(restaurantId);
            return _mapper.Map<List<MenuItemDto>>(menuItems);
        }


    }
}
