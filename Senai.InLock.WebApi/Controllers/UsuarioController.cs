using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Repositories;
using Senai.InLock.WebApi.ViewModel;

namespace Senai.InLock.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        UsuariosRepository usuariosRepository = new UsuariosRepository();

        [HttpGet]

        public IActionResult Listar()
        {
            return Ok(usuariosRepository.Listar());
        }

        [HttpPost]

        public IActionResult Login(LoginViewModel login)
        {
            Usuarios Usuario = usuariosRepository.Login(login);
            if (Usuario == null)
            {
                return NotFound(new { mensagem = "Email ou senha inválidos." });
            }

            var claims = new[]
            {
                    new Claim(JwtRegisteredClaimNames.Email, Usuario.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Usuario.IdUsuario.ToString()),
                    new Claim(ClaimTypes.Role, Usuario.IdPermissaoNavigation.Tipo),
                };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("InLock-chave-autenticacao"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "InLock.WebApi",
                audience: "InLock.WebApi",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);


            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });

        }
    }
}