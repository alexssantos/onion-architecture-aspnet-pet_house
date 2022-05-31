using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetHouse.ContractsDto.Auth;
using PetHouse.Services.Abstractios;
using System.Net.Mime;

namespace PetHouse.Presentation.Controllers
{
    [Authorize]
    [Route("api/pets")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    public class PetController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public PetController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UsuarioParaLoginDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("todos")]
        public async Task<IActionResult> ObterTodos(CancellationToken cancellationToken = default)
        {
            return Ok(await _serviceManager.UsuarioService.ObterTodosAsync(cancellationToken));
        }
    }
}
