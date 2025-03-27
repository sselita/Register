using Core.Entities;

namespace Infrastructure.Repositories
{
    public interface IUserRepository
    {
        Task AddUserAsync(User user);
        Task<User> GetUserByEmailAsync(string email);
        Task<User> GetUserByIdAsync(int userId);
        Task<User> GetUserByMobileNumberAsync(string mobileNumber);
        Task UpdateUserAsync(User user);
        Task<User> GetUserByICNuberAsync(string ICNumber);
    }
}