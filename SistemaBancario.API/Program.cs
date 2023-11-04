using SistemaBancario.Infra.Ioc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


//builder.Services.AddSwaggerGen();
// Subistituimos por nosso método AddInfraStrucureSwagger que adiciona o token de autorização
builder.Services.AddInfraStructureSwagger();
//método AddInfrastructure que contem nossas injeções de dependencia,
//nossa string de conexão e migrations
DependencyInjection.AddInfrastructure(builder);


var app = builder.Build();

//Adicionando a injeção de dependencia de autenticação e autorização
app.UseAuthentication();
app.UseAuthorization();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
