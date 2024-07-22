using Domain.Entities;

namespace Application.Services.UserService
{
    public interface IUserService
    {
        Task<User> GetUserByEmailAsync(string email);
    }
}
