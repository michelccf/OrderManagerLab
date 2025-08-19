using Resouces.DTOs;
using Resouces.Entities;

namespace UserApi.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<bool> CreateAccount(UserData user);
        Task<UserData> Login(UserDto user);
    }
}
