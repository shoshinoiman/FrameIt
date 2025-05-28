using FrameIt.Core.Dto;
using FrameIt.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameIt.Core.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserByEmailAsync(string email);
        Task<User> GetUserByIdAsync(int id);
        Task<User> AddUserAsync(User user);
        Task SaveChangesAsync();
        Task<User> UpdateAsync(User user);
        Task<bool> DeleteUserAsync(int id);
    }
}
