using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Logging;

namespace Poker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost("Token")]
        public async Task Token(LoginRequest loginRequest)
        {
            try
            {
                var success = API.Token.Token.Validate(userInfo);
                if (success)
                {
                    var token = API.Token.Token.BuildToken(userInfo);
                    return Ok(token);
                }

                ModelState.AddModelError(string.Empty, "Login inválido!");
                return BadRequest(ModelState);
            }
            catch (Exception error)
            {
                LogHelper.Error("Ocorreu um erro ao obter o token", error);
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao obter o token");
            }
        }
    }
}
