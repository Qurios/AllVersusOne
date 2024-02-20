using AllVersusOne.DataModel.Enums;
using AllVersusOne.Services;
using AllVersusOne.Services.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AllVersusOne.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController(IUserService userService) : ControllerBase
    {
        [HttpPost("create-user")]
        public async Task<int> AddNewUser([FromBody] CreateUserDto user)
        {
            var dbUser = await userService.CreateUser(user.Name ?? "", user.Group ?? "", UserType.User);
            return dbUser.Id;
        }

        [HttpPost("get-users")]
        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            var dbUsers = await userService.GetUsers();
            return dbUsers.Select(u => new UserDto
            {
                Id = u.Id,
                Name = u.Name,
                Group = u.Group,
            });
        }

        [HttpGet("get-winner")]
        public UserDto GetRandomUser(IEnumerable<int> gameRoundIds)
        {
            throw new NotImplementedException();
        }


    }
}
