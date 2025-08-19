using Resouces.DTOs;
using Resources.DTOs;

namespace UserApi.Interfaces.Services
{
    public interface IUserService
    {
        Task<UserDto> Login(Login login);
        Task<bool> CreateAccount(UserDto user);
    }
}
