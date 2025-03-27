using Microsoft.AspNetCore.Mvc;
using Poker.Service.DTOs.Token;
using Poker.Service.Interfaces.Services;

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
        public async Task<IActionResult> Token([FromBody] TokenRequest tokenRequest)
        {
            try
            {
                var token = await _tokenService.GenerateToken(tokenRequest);
                return Ok(token);
            }
            catch (NullReferenceException error)
            {
                return BadRequest(error.Message);
            }
            catch (UnauthorizedAccessException error)
            {
                return Unauthorized(error.Message);
            }
            catch (Exception)
            {
                //TODO Criar log do erro
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao obter o token");
            }
        }
    }
}
