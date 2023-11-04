using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using SistemaBancario.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

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

            //Adicionando a injeção de dependencia da autorização do JWT

            builder.Services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }
            ).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true, // validar quem que gera o token
                    ValidateAudience = true, // valida o destinatario
                    ValidateLifetime = true, // tempo que sera valido o token
                    ValidateIssuerSigningKey = true, // valida o login

                    //informações sensiveis pra isolar depois no appSettings
                    ValidIssuer = builder.Configuration["jwt:issuer"],
                    ValidAudience = builder.Configuration["jwt:audience"],
                    //chave secreta utilizando o conversor com Encoding UTF8
                    IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(builder.Configuration["jwt:secretkey"])),
                    ClockSkew = TimeSpan.Zero
                };
            });
        }

    }
}
