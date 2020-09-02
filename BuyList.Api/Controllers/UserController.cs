using BuyList.Api.Auth;
using BuyList.Domain.Commands.Responses;
using BuyList.Domain.Commands.UserCommands;
using BuyList.Domain.Entities;
using BuyList.Domain.Handlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace BuyList.Api.Controllers
{
    [ApiController]
    [Route("v1/users")]
    public class UserController : ControllerBase
    {
        private readonly AppSettings _appSettings;

        public UserController(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        [Route("")]
        [HttpPost]
        public async Task<GenericCommandResult> Create([FromBody] CreateUserCommand command, [FromServices] UserHandler handler)
        {
            return (GenericCommandResult)await handler.Handle(command);
        }

        [Authorize]
        [Route("")]
        [HttpPut]
        public async Task<GenericCommandResult> Update([FromBody] UpdateUserCommand command, [FromServices] UserHandler handler)
        {
            return (GenericCommandResult)await handler.Handle(command);
        }

        [Route("login")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command, [FromServices] UserHandler handler)
        {
            var result = await handler.Handle(command);

            if (result.Success == false)
                return BadRequest(command.Notifications);

            User user = (User)result.Data;
            var token = TokenService.GenerateToken(user, _appSettings);

            return Ok(new { userId = user.Id, user = user.Name, email = user.Email, token = token });
        }
    }
}