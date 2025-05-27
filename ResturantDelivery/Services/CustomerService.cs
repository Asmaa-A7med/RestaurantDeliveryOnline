using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using ResturantDelivery.Data;
using ResturantDelivery.Dtos;
using ResturantDelivery.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ResturantDelivery.Services
{
    public class CustomerService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public CustomerService(UnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configuration = configuration;
        }
        public async Task<string?> RegisterAsync(CustomerRegisterDto dto)
        {
            var existingCustomer = await _unitOfWork.Customers.GetByEmailAsync(dto.Email);

            if (existingCustomer != null)
                return null;

            var customer = _mapper.Map<Customer>(dto);
            customer.PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            await _unitOfWork.Customers.Add(customer);
            await _unitOfWork.SaveChangesAsync();

            return GenerateJwtToken(customer);  
        }

        public async Task<TokenResponseDto?> LoginAsync(CustomerLoginDto dto)
        {
            var customer = await _unitOfWork.Customers.GetByEmailAsync(dto.Email);

            if (customer == null || !BCrypt.Net.BCrypt.Verify(dto.Password, customer.PasswordHash))
                return null;

            var accessToken = GenerateJwtToken(customer);  
            var refreshToken = GenerateRefreshToken();

            customer.RefreshToken = refreshToken;
            customer.RefreshTokenExpiryTime = DateTime.UtcNow.AddMinutes(10);  

            await _unitOfWork.SaveChangesAsync();

            return new TokenResponseDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
        }

        private string GenerateJwtToken(Customer customer)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, customer.Id.ToString()),
                new Claim(ClaimTypes.Email, customer.Email),
                new Claim(ClaimTypes.Name, customer.FullName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(3),  
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = System.Security.Cryptography.RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
    }
}