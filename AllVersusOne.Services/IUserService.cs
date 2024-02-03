using AllVersusOne.DataModel.Entities;
using AllVersusOne.DataModel.Enums;

namespace AllVersusOne.Services
{
    public interface IUserService
    {
        Task<User> CreateUser(string name, string group, UserType type);

        Task<IEnumerable<User>> GetUsers();
    }
}
