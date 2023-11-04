using SistemaBancario.Infra.Ioc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


//builder.Services.AddSwaggerGen();
// Subistituimos por nosso m�todo AddInfraStrucureSwagger que adiciona o token de autoriza��o
builder.Services.AddInfraStructureSwagger();
//m�todo AddInfrastructure que contem nossas inje��es de dependencia,
//nossa string de conex�o e migrations
DependencyInjection.AddInfrastructure(builder);


var app = builder.Build();

//Adicionando a inje��o de dependencia de autentica��o e autoriza��o
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
