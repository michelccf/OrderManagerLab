using Resouces.DTOs;
using Resouces.Entities;
using Resources.DbContextService;
using Resources.DTOs;
using UserApi.Interfaces.Repositories;

namespace UserApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContextService _dbContext;
        public UserRepository(DbContextService dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> CreateAccount(UserData user)
        {
            _dbContext.UserData.Add(user);
            int lines = await _dbContext.SaveChangesAsync();

            return lines > 0;
        }

        public async Task<UserData> Login(Login login)
        {
           return _dbContext.UserData.Where(_ => _.Email == login.Email).FirstOrDefault();
        }
    }
}
