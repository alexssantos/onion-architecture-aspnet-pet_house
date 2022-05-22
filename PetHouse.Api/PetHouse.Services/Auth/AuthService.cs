using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PetHouse.ContractsDto.Auth;
using PetHouse.Domain.Repositories;
using PetHouse.Services.Abstractios;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PetHouse.Services.Auth
{
    internal sealed class AuthService : IAuthService
    {
        private IConfiguration Configs { get; set; }
        private IRepositoryManager RepositoryManager { get; set; }


        public AuthService(IConfiguration configs, IRepositoryManager repositoryManager)
        {
            Configs = configs;
            RepositoryManager = repositoryManager;
        }

        public string GerarToken(UsuarioParaLoginDto usuario)
        {
            var secret = Configs.GetSection(AuthSecretOptions.AuthSecret).Value;
            var key = Encoding.ASCII.GetBytes(secret);

            // Configurando o token gerado.
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                // variaveis que ficarao disponiveis pra visualização e itens usados no token.
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuario.Nome),
                    new Claim(ClaimTypes.Email, usuario.Email),
                    new Claim(ClaimTypes.Role, usuario.TipoUsuarioStr),
                    new Claim(ClaimTypes.NameIdentifier, usuario.Login),
                }),
                // Tempo de expiração.
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(
                    // usando security key tipo SIMETRICA.
                    new SymmetricSecurityKey(key),
                    // Algoritmo de encriptação.
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            // converter para string.
            return tokenHandler.WriteToken(token);
        }
    }
}
