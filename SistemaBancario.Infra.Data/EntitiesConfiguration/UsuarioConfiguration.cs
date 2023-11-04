using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaBancario.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBancario.Infra.Data.EntitiesConfiguration
{
    // referenciando o IEntityTypeConfiguration do entityFrameworkCore passando o type a classe Usuario
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        //criamos o método de configuração da nossa classe Usuario, para estar setando as configurações
        //das propertyes da nossa tabela
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(x => x.Id);//Primary key
            builder.Property(x => x.Nome).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Cpf).HasMaxLength(11).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(100).IsRequired();
            builder.Property(x => x.NumeroCelular).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Estado).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Cidade).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Bairro).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Endereco).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Numero).HasMaxLength(100).IsRequired();
        }
    }
}
