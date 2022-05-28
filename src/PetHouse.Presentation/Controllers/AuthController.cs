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
        public ActionResult Login([FromBody] AuthLoginRequest loginForm)
        {
            var user = ServiceManager.UsuarioService.ObterUsuarioParaLogin();

            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos." });

            var token = ServiceManager.AuthService.GerarToken(user);
            loginForm.Senha = "";

            return Ok(new
            {
                user = user,
                //tipoUsuario = user.TipoUsuario,
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
