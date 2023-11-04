using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SistemaBancario.Domain.Entities;
using SistemaBancario.Infra.Data.Context;
using SistemaBancario.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBancario.Infra.Data.Identity
{
    //classe com nossos serviços
    public class AuthenticateService : IAuthenticate
    {
        //instancia do nosso contexto
        private readonly ApplicationDbContext _context;
        //instancia da nossa configuração para recuperar as configuraç~eos no nosso appsetings
        private readonly IConfiguration _configuration;

        //construtor da nossa classe, fazendo a injeção de dependencia
        public AuthenticateService(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<bool> AuthenticateAsync(string email, string senha)
        {
            //buscar no contexto o usuario testando se o email inforamado e igual o email no banco
            var usuario = await _context.Usuario.Where(x => x.Email.ToLower() == email.ToLower()).FirstOrDefaultAsync();
            if (usuario == null)
            {
                return false;
            }

            //teste de senha
            // vai transformar a senha em HMACSHA512 bite
            using var hmac = new HMACSHA512(usuario.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(senha));
            //vai testar byte por byte e se tiver algo diferente ele já retorna false
            for (int x = 0; x < computedHash.Length; x++)
            {
                if (computedHash[x] != usuario.PasswordHash[x]) return false;
            }

            return true;
        }

        //vai gerar nosso token
        public string GenerateToken(int id, string email)
        {
            var claims = new[]
            {
                new Claim("id", id.ToString()),
                new Claim("email",email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var privateKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["jwt:secretKey"]));

            var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddMinutes(10);

            //gera nosso token
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _configuration["jwt:issuer"],
                audience: _configuration["jwt:audience"],
                claims: claims,
                expires: expiration,
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<bool> UserExists(string email)
        {
            //buscar no contexto o usuario testando se o email inforamado e igual o email no banco
            var usuario = await _context.Usuario.Where(x => x.Email.ToLower() == email.ToLower()).FirstOrDefaultAsync();
            if (usuario == null)
            {
                return false;
            }

            return true;
        }

        public async Task<Usuario> GetUserByEmail(string email)
        {
            var user = await _context.Usuario.Where(x => x.Email.ToLower().Equals(email.ToLower())).FirstOrDefaultAsync();

            return user;
        }

    }
}
