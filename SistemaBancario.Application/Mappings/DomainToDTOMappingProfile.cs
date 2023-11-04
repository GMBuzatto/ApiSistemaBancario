using AutoMapper;
using SistemaBancario.Application.DTOs;
using SistemaBancario.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBancario.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            //Método que cria o mapeamento e permite o ReverseMap tanto do Usuario pro UsuarioDTO
            //quanto do UsuarioDTO pro Usuario
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
        }
    }
}
