using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetHouse.ContractsDto.Pet;
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

        [ProducesResponseType(typeof(IEnumerable<PetDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet, Route("todos")]
        public async Task<IActionResult> ObterTodos(CancellationToken cancellationToken = default)
        {
            return Ok(await _serviceManager.PetService.ObterTodosAsync(cancellationToken));
        }

        [ProducesResponseType(typeof(IEnumerable<PetDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost, Route("cadastro")]
        public async Task<IActionResult> CadastrarPet([FromBody] NovoPet novoPet, CancellationToken cancellationToken = default)
        {
            return Ok(await _serviceManager.PetService.Cadastrar(novoPet, cancellationToken));
        }
    }
}
