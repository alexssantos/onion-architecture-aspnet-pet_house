using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PetHouse.ContractsDto.Auth;
using PetHouse.Services.Abstractios;

namespace PetHouse.Presentation.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IServiceManager ServiceManager;

        public AuthController(IServiceManager serviceManager)
        {
            ServiceManager = serviceManager;
        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] AuthLoginRequest loginForm, CancellationToken cancellationToken = default)
        {
            var user = await ServiceManager.UsuarioService.ObterUsuarioParaLoginAsync(loginForm.Usuario, loginForm.Senha, cancellationToken);
            var token = ServiceManager.AuthService.GerarToken(user);

            return Ok(new
            {
                usuario = user,
                token = token
            });
        }

        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("anonimo")]
        public string Anonimo() => "Você está habilitado no modo anônimo.";

        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("autenticado")]
        public string Autenticado() => string.Format("Você está Autenticado - {0}.", User.Identity?.Name);

        [HttpGet]
        [Authorize(Roles = "FUNCIONARIO")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("funcionario")]
        public string Funcionario() => string.Format("Você é uma FUNCIONARIO autorizado - {0}.", User.Identity?.Name);

        [HttpGet]
        [Authorize(Roles = "CLIENTE")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("cliente")]
        public string Cliente() => string.Format("Você é um CLIENTE autorizado - {0}.", User.Identity?.Name);
    }
}
