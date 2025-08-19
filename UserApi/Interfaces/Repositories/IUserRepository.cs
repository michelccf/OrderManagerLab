using Resouces.Entities;
using Resources.DTOs;

namespace UserApi.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<bool> CreateAccount(UserData user);
        Task<UserData> Login(Login user);
    }
}
