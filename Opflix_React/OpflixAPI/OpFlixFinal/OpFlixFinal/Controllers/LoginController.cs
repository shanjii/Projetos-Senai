using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OpFlixFinal.Domains;
using OpFlixFinal.Interfaces;
using OpFlixFinal.Repositories;
using OpFlixFinal.ViewModels;

namespace OpFlixFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private IUsuarioRepository usuarioRepository { get; set; }

        public LoginController()
        {
            usuarioRepository = new UsuarioRepository();
        }

        public IActionResult Login(LoginViewModel login)
        {
            Usuarios usuarioBuscado = usuarioRepository.BuscarEmailSenha(login);
            if (usuarioBuscado == null)
            {
                return NotFound(new { mensagem = "Email ou Senha Inválidos." });
            }
            else
            {

                var claims = new[]
                  {
                    // chave customizada
                    new Claim("chave", "0123456789"),
                    new Claim(usuarioBuscado.NomeUsuario, "AgoraVai"),
                    // email
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.NomeUsuario),
                    // id
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                    // permissao
                    new Claim(ClaimTypes.Role, usuarioBuscado.Permissao),
                    new Claim("Permissao", usuarioBuscado.Permissao),
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("OpFlix-chave-autenticacao"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "OpFlix.WebApi",
                    audience: "OpFlix.WebApi",
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
}