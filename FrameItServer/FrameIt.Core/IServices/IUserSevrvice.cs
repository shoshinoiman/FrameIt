using FrameIt.Core.Dto;
using FrameIt.Core.Items;
using FrameIt.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameIt.Core.Services
{
    public interface IUserService
    {
        Task<string> RegisterAsync(RegisterDto request);
        Task<string> LoginAsync(LoginDto request);
        Task<UserDto> GetUserByIdAsync(int userId);
        //Task<bool> UpdateUserAsync(int userId, UpdateUserDto request);
        //Task<bool> DeleteUserAsync(int userId);
         string GenerateJwtToken(User user);
        Task<UserDto> UpdateUserAsync(int id, UpdateUserDto userUpdateDTO);
        Task<ApiResponse<bool>> DeleteUserAsync(int id);

    }

}
