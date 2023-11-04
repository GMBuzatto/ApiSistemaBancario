using SistemaBancario.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBancario.Infra.Data.Interfaces
{
    public interface IAuthenticate
    {
        Task<bool> AuthenticateAsync(string email, string senha);

        Task<bool> UserExists(string email);

        public string GenerateToken(int id, string email);

        // contrato que vai ser sobreescrito para selecionar o usuario e retornar

        public Task<Usuario> GetUserByEmail(string email);
    }
}

