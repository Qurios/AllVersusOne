using AllVersusOne.DataModel.Enums;
using AllVersusOne.Services;
using AllVersusOne.Services.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AllVersusOne.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpPost("create-user")]
        public async Task<int> AddNewUser([FromBody] CreateUserDto user)
        {
            var dbUser = await _userService.CreateUser(user.Name ?? "", user.Group ?? "", UserType.User);
            return dbUser.Id;
        }

        [HttpPost("get-users")]
        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            var dbUsers = await _userService.GetUsers();
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
