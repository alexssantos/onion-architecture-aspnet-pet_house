using Microsoft.AspNetCore.Authorization;
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
        [Route("login")]
        [AllowAnonymous]
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
        [Route("anonimo")]
        [AllowAnonymous]
        public string Anonimo() => "Você está habilitado no modo anônimo.";

        [HttpGet]
        [Route("autenticado")]
        [Authorize]
        public string Autenticado() => string.Format("Você está Autenticado - {0}.", User.Identity?.Name);

        [HttpGet]
        [Route("funcionario")]
        [Authorize(Roles = "FUNCIONARIO")]
        public string Funcionario() => string.Format("Você é uma funcionario autorizadO - {0}.", User.Identity?.Name);

        [HttpGet]
        [Route("cliente")]
        [Authorize(Roles = "CLIENTE")]
        public string Cliente() => string.Format("Você é um cliente autorizado - {0}.", User.Identity?.Name);
    }
}
