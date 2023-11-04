using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaBancario.Infra.Ioc
{
    //Configuração de autorização no swagger JWT
    public static class DependencyInjectionSwagger
    {
        // lembrar de passar o this IServiceCollection que então ele vai se referenciado 
        // dentro do nossos services, na nossa program da API
        public static IServiceCollection AddInfraStructureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                //Definição do nosso token
                c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JSON Web Tokens (JWT) are an open, industry standard RFC 7519 method for representing claims securely between two parties.",
                });

                //Configuração do nosso token
                c.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme()
                        {
                            Reference = new OpenApiReference()
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string []
                        {

                        }
                    }
                });
            });

            return services;
        }
    }
}
