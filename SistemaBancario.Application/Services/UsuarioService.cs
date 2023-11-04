using AutoMapper;
using SistemaBancario.Application.DTOs;
using SistemaBancario.Application.Interfaces;
using SistemaBancario.Domain.Entities;
using SistemaBancario.Infra.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBancario.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        // instancia do nosso IUsuarioRepository
        private readonly IUsuarioRepository _repository;
        //instancia do mapper pra ajudar no mapeamento do Usuario para o UsuarioDTO
        private readonly IMapper _mapper;

        //construtor da nossa classe
        public UsuarioService(IUsuarioRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UsuarioDTO> Alterar(UsuarioDTO usuarioDTO)
        {
            //buscando o usuario pelo mapper passando o type Usuario informando o usuarioDTO
            //pois precisamos mapear o Usuario apartir do usuarioDTO
            var usuario = _mapper.Map<Usuario>(usuarioDTO);
            // buscando o método Alterar no nosso repositorio, informando usuario de modo async, por isso await
            var usuarioAlterado = await _repository.Alterar(usuario);
            // retornando para o map o type UsuarioDTO informando o usuarioAlterado
            return _mapper.Map<UsuarioDTO>(usuarioAlterado);
        }

        public async Task<UsuarioDTO> Excluir(int id)
        {
            // buscando o método Exlcuir do nosso repositorio, informando o id de modo async, por isso await
            var usuarioExcluido = await _repository.Excluir(id);
            // retornando o usuarioExcluido para o map com o type UsuarioDTO
            return _mapper.Map<UsuarioDTO>(usuarioExcluido);
        }

        public async Task<UsuarioDTO> Incluir(UsuarioDTO usuarioDTO)
        {
            //buscar pelo map o type Usuario informando o usuarioDTO
            //pois precisamos mapear o Usuario apartir do usuarioDTO
            var usuario = _mapper.Map<Usuario>(usuarioDTO);
            //criando nossa passwordHash e passwordSalt
            if (usuarioDTO.Password != null)
            {
                using var hmac = new HMACSHA512();
                byte[] passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(usuarioDTO.Password));
                byte[] passwordSalt = hmac.Key;

                usuario.AlterarSenha(passwordHash, passwordSalt);

            }

            //buscar o método alterar no repositorio informando o usuario buscado de modo async, por isso await
            var usuarioAdicionado = await _repository.Alterar(usuario);
            //retornado o usuarioAdicionado para o map com type usuarioDTO
            return _mapper.Map<UsuarioDTO>(usuarioAdicionado);
        }

        public async Task<UsuarioDTO> SelecionarAsync(int id)
        {
            // busca o usuario atravez do método do repositoru SelecionarAsync, passando o id
            // de modo async por isso await
            var usuario = await _repository.SelecionarAsync(id);
            return _mapper.Map<UsuarioDTO>(usuario);
        }

        public async Task<IEnumerable<UsuarioDTO>> SelecionarTodosAsync()
        {
            // busca os usuarios através do método do repository SelecionarTodosAsync, de forma async
            // por isso await
            var usuarios = await _repository.SelecionarTodosAsync();
            return _mapper.Map<IEnumerable<UsuarioDTO>>(usuarios);
        }
    }
}
