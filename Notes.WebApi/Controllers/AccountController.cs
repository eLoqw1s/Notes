using Microsoft.AspNetCore.Mvc;
using Notes.Application.Services;
using Notes.WebApi.Contracts.Users;

namespace Notes.WebApi.Controllers
{
    public class AccountController : BaseController
    {
        private readonly UsersService _userService;

        public AccountController(UsersService userService)
        {
            _userService = userService;
        }

        [HttpPost("/register")]
        public async Task<IResult> Register(RegisterUserRequest request)
        {
            await _userService.Register(request.UserName, request.Email, request.Password);

            return Results.Ok();
        }

        [HttpPost("/login")]
        public async Task<IResult> Login(LoginUserRequest request)
        {
            var token = await _userService.Login(request.Email, request.Password);

            Response.Cookies.Append("notJwtToken", token);
            
            return Results.Ok();
        }
    }
}
