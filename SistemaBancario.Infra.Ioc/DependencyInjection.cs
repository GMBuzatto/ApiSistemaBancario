using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaBancario.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBancario.Infra.Ioc
{
    public static class DependencyInjection
    {
        //método AddInfrastructure que vai ser chamado com DependencyInjection na program
        public static void AddInfrastructure(this WebApplicationBuilder builder)
        {

            //injeção de dependencia que busca nossa string de conexão e nossas migrations
            //atraves do nosso contexto
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
            });
        }

    }
}
