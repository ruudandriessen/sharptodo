using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Todo.Storage;
namespace Todo.API.Controllers;

[ApiController]
[Route("login")]
public class UserController : ControllerBase
{
    private IUserRepository _repository;

    public UserController(IUserRepository repository)
    {
        this._repository = repository;
    }

    [Authorize]
    [HttpPost]
    [ProducesResponseType<TodoDto>(StatusCodes.Status200OK)]
    public async Task<ActionResult<TodoDto>> Login()
    {

        var Jwt = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
        var handler = new JwtSecurityTokenHandler();
        var Token = handler.ReadJwtToken(Jwt);

        var Email = Token.Payload["email"].ToString();

        if (Email == null)
        {
            return BadRequest();
        }

        var User = await this._repository.Get(Email);
        if (User == null)
        {
            await this._repository.Add(
                new UserAo()
                {
                    Id = Email,
                    Name = Token.Payload["name"].ToString(),
                    Email = Email
                }
            );
        }

        return Ok();
    }
}
