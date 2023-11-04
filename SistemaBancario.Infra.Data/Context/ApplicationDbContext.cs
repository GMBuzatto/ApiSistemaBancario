using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBancario.Infra.Data.Context
{
    //AplicationDbContext herda o DbContext do EntityFramework
    public class ApplicationDbContext : DbContext
    {
        //construtor passando o DbContextOptions pra podermos configurar
        public ApplicationDbContext(DbContextOptions options) : base(options) { }


        //Aqui vai ficar nossos DbSet's, seria as tabelas, nossas entidades
        //...

        //sobreescrevendo o método OnModelCreating passando ModelBuilder
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //ele vai procurar as configurações das entities no projeto Infra Data,
            //atraves do Assembly que vai procurar varrer o projeto
            //e encontrar a pasta EntitiesConfigurations
            //onde vai ficar as propriedades do banco de dados das entidades
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
