using AutoMapper;
using ResturantDelivery.Data;
using ResturantDelivery.Dtos;

namespace ResturantDelivery.Services
{
    public class cityService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public cityService(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<List<citiesDto>> GetAllCitiesAsync()
        {
            var cities = await _unitOfWork.Cities.GetAllCitiesAsync();
            return _mapper.Map<List<citiesDto>>(cities);
        }
    

}
}
