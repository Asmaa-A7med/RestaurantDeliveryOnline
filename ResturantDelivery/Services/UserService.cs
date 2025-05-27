using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto.Generators;
using ResturantDelivery.Data;
using ResturantDelivery.Dtos;
using ResturantDelivery.Models;
using System;

namespace ResturantDelivery.Services
{
    public class UserService
    {

        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> RegisterAsync(RegisterDto dto)
        {
            // Check if user already exists by email
            var existingUser = await _unitOfWork.Users.GetByEmailAsync(dto.Email);
            if (existingUser != null)
                return false;

            // Map from DTO to User entity
            var user = _mapper.Map<User>(dto);

            // Hash the password
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            // Add and save
            await _unitOfWork.Users.Add(user);  


            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}