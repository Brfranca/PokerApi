using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Logging;
using Poker.Service.DTOs.Token;
using Poker.Service.Interfaces;

namespace Poker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        public TokenController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost()]
        public IActionResult Token([FromBody] TokenRequest tokenRequest)
        {
            try
            {
                var success = _tokenService.Validate(tokenRequest);

                if (success)
                {
                    var token = _tokenService.GenerateToken(tokenRequest);
                    return Ok(token);
                }

                ModelState.AddModelError(string.Empty, "Login inválido!");
                return BadRequest(ModelState);
            }
            catch (Exception error)
            {
                //LogHelper.Error("Ocorreu um erro ao obter o token", error);
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao obter o token");
            }
        }
    }
}
