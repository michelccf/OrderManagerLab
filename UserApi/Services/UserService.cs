using Resouces.DTOs;
using Resouces.Entities;
using Resources.DTOs;
using UserApi.Interfaces.Repositories;
using UserApi.Interfaces.Services;

namespace UserApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto> Login(Login login) 
        {
            UserDto userDto = new UserDto();
            userDto.Email = login.Email;
            userDto.Password = login.Password;

            UserData result = await _userRepository.Login(userDto);

            UserDto resultUserDto = new UserDto() {Id = result.Id,Alias = result.Alias, Address = result.Address, Email = result.Email, Name = result.Name, Password = result.Password, Telephone = result.Telephone };

            return resultUserDto;
        }

        public async Task<bool> CreateAccount(UserDto user)
        {
            UserData data = new UserData();
            data.Address = user.Address;
            data.Password = user.Password;
            data.Email = user.Email;
            data.Alias = user.Alias;
            data.Telephone = user.Telephone;
            data.Name = user.Name;

           return  await _userRepository.CreateAccount(data);

        }

    }
}
