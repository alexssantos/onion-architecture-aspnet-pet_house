using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetHouse.ContractsDto.Auth;
using PetHouse.ContractsDto.Usuario;
using PetHouse.Services.Abstractios;

namespace PetHouse.Presentation.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public UsuarioController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(typeof(UsuarioParaLoginDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("criar")]
        public async Task<IActionResult> CriarUsuario([FromBody] UsuarioParaCriacaoDto usuario, CancellationToken cancellationToken = default)
        {
            var user = await _serviceManager.UsuarioService.CriarUsuarioFuncionario(usuario, cancellationToken);
            return Ok(user);
        }

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(typeof(IEnumerable<UsuarioParaLoginDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("todos")]
        public async Task<IActionResult> ObterTodos(CancellationToken cancellationToken = default)
        {
            return Ok(await _serviceManager.UsuarioService.ObterTodosAsync(cancellationToken));
        }
    }
}
