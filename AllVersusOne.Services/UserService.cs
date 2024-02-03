using AllVersusOne.DataModel.Entities;
using AllVersusOne.DataModel.Enums;
using AllVersusOne.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AllVersusOne.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWorkManager _uowManager;
        private readonly IRepository<User> _userRepository;

        public UserService(IUnitOfWorkManager uowManager, IRepository<User> userRepository)
        {
            this._uowManager = uowManager;
            this._userRepository = userRepository;
        }

        public async Task<User> CreateUser(string name, string group, UserType type)
        {
            using var uow = _uowManager.Begin();

            var user =  await _userRepository.AddAsync(new User()
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
            return await _userRepository.Many().Take(10).ToListAsync();
        }
    }
}
