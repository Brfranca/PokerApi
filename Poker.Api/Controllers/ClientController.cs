using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Poker.Service.DTOs.Client;
using Poker.Service.Interfaces.Services;

namespace Poker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpPost("Create")]
        public IActionResult Insert(ClientRequest client)
        {
            _clientService.Create(client);
            return Created();
        }
    }
}
