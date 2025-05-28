using AutoMapper;
using FrameIt.Core.Dto;
using FrameIt.Core.Items;
using FrameIt.Core.Repositories;
using FrameIt.Core.Services;
using FrameIt.Data.Items;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Exchange.WebServices.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FrameIt.service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly PasswordHasher<User> _passwordHasher;

        public UserService(IUserRepository userRepository, IMapper mapper, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _passwordHasher = new PasswordHasher<User>();
            _configuration = configuration;
        }

        public async Task<string> RegisterAsync(RegisterDto request)
        {
            if (await _userRepository.GetUserByEmailAsync(request.Email) != null)
                return null;

            var user = _mapper.Map<User>(request);
            user.PasswordHash = _passwordHasher.HashPassword(null, request.Password);
            user.Role = "User";
            user = await _userRepository.AddUserAsync(user);
            await _userRepository.SaveChangesAsync();
            return GenerateJwtToken(user);
        }

        public async Task<string> LoginAsync(LoginDto request)
        {
            var user = await _userRepository.GetUserByEmailAsync(request.Email);
            if (user == null)
                return null;

            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, request.Password);
            if (result == PasswordVerificationResult.Failed)
                return "Invalid password.";
            return GenerateJwtToken(user);
        }


        public async Task<UserDto> GetUserByIdAsync(int userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);
            if (user == null)
                return null;

            return _mapper.Map<UserDto>(user);
        }


        public async Task<UserDto> UpdateUserAsync(int id, UpdateUserDto userUpdateDTO)
        {
            var userById = await _userRepository.GetUserByIdAsync(id);
            if (userById == null)
            {
                return null; 
            }
            var user = _mapper.Map<User>(userUpdateDTO);

            user.Id = id;
            user.Role = userById.Role;
            var updatedUser = await _userRepository.UpdateAsync(user);
            return _mapper.Map<UserDto>(updatedUser);
        }




        //public async Task<bool> DeleteUserAsync(int userId)
        //{
        //    var user = await _userRepository.GetUserById(userId);
        //    if (user == null)
        //        return false;

        //    await _userRepository.DeleteUser(user);
        //    await _userRepository.SaveChanges();
        //    return true;
        //}

        public string GenerateJwtToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(60 * 24),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        //public async Task<ApiResponse<bool>> DeleteUserAsync(int id)
        //{
        //    var user = await _userRepository.GetUserByIdAsync(id);
        //    if (user == null)
        //    {
        //        return new ApiResponse<bool>
        //        {
        //            Success = false,
        //            Data = false,
        //            Message = "User not found."
        //        };
        //    }

        //    if (user.IsAdmin)
        //    {
        //        return new ApiResponse<bool>
        //        {
        //            Success = false,
        //            Data = false,
        //            Message = "Cannot delete admin user."
        //        };
        //    }

        //    var deleted = await _userRepository.DeleteUserAsync(id);
        //    return new ApiResponse<bool>
        //    {
        //        Success = deleted,
        //        Data = deleted,
        //        Message = deleted ? "User deleted successfully." : "Failed to delete user."
        //    };
        //}

        public async Task<ApiResponse<bool>> DeleteUserAsync(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                return new ApiResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "User not found."
                };
            }

            if (user.IsAdmin)
            {
                return new ApiResponse<bool>
                {
                    Success = false,
                    Data = false,
                    Message = "Cannot delete admin user."
                };
            }

            var deleted = await _userRepository.DeleteUserAsync(id);
            return new ApiResponse<bool>
            {
                Success = deleted,
                Data = deleted,
                Message = deleted ? "User deleted successfully." : "Failed to delete user."
            };
        }

    }

}
