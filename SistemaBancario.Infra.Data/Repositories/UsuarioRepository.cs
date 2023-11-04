using Microsoft.EntityFrameworkCore;
using SistemaBancario.Domain.Entities;
using SistemaBancario.Infra.Data.Context;
using SistemaBancario.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBancario.Infra.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        //instanciando nosso contexto
        private readonly ApplicationDbContext _context;

        //criando construtor com nosso contexto
        public UsuarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> Alterar(Usuario usuario)
        {
            //método update do entityframework, passando o usuario
            _context.Usuario.Update(usuario);
            //aguardando o método SaveChangeAsync do entityframework salvar
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> Excluir(int id)
        {
            //buscando o usuario informando o id
            var usuario = await _context.Usuario.Where(x => x.Id == id).FirstOrDefaultAsync();
            //método remove do entityframework, passando o usuario buscado pelo id fornecido
            _context.Usuario.Remove(usuario);
            //salvando as alterações
            await _context.SaveChangesAsync();
            return usuario;
        }

       public async Task<Usuario> Incluir(Usuario usuario)
        {
            //adicionando o usuario informado, como o método Add do entityframework
            _context.Usuario.Add(usuario);
            //salvando as alterações de maneira sincrona
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> SelecionarAsync(int id)
        {
            //buscando o usuario informando o id pelo método Wherer do entityFramework, de modo async
            var usuario = await _context.Usuario.Where(x => x.Id == id).FirstOrDefaultAsync();
            return usuario;
        }

        public async Task<IEnumerable<Usuario>> SelecionarTodosAsync()
        {
            //buscando os usuarios pelo método ToListAsync do entityframework
            var usuarios = await _context.Usuario.ToListAsync();
            return usuarios;
        }
    }
}
