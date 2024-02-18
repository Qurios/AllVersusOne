using AllVersusOne.DataModel.Entities;
using AllVersusOne.DataModel.Enums;
using AllVersusOne.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AllVersusOne.Services
{
    public class UserService(IUnitOfWorkManager uowManager, IRepository<User> userRepository)
        : IUserService
    {
        public async Task<User> CreateUser(string name, string group, UserType type)
        {
            using var uow = uowManager.Begin();

            var user =  await userRepository.AddAsync(new User()
            {
                Name = name,
                Group = group,
                Type = type,
            });

            await uow.SaveAsync();
            return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await userRepository.Many().Take(10).ToListAsync();
        }
    }
}
