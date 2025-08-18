using Resouces.DTOs;
using Resources.DTOs;

namespace ApiGatway.Interfaces
{
    public interface IUserService
    {
        Task<string> Login(Login loginData);
        Task<bool> CreateAccount(UserDto userData);
    }
}
