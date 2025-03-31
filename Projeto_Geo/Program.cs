using Microsoft.EntityFrameworkCore;
using Projeto_Geo.Domain;
using Projeto_Geo.Repository;
using Projeto_Geo.Repository.Consultas;
using Projeto_Geo.Servicos;

var builder = WebApplication.CreateBuilder(args);

// Adicionar servi�os ao cont�iner

builder.Services.AddControllers();
// Saiba mais sobre a configura��o do Swagger/OpenAPI em https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//-- servi�os

// Conex�o com o banco de dados
var connectionstring = builder.Configuration.GetConnectionString("geoprefeitura");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionstring, ServerVersion.AutoDetect(connectionstring)));

// Registrar os servi�os necess�rios
builder.Services.AddScoped<BaseDadosRepository>();
builder.Services.AddScoped<PopularBancoBasePrefeitura>();
builder.Services.AddScoped<BaseDados>();
builder.Services.AddScoped<ValidadorXLSX>();


var app = builder.Build();

// Configurar o pipeline de requisi��o HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Criar um escopo para resolver o AppDbContext e os outros servi�os corretamente
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    var baseDadosRepository = scope.ServiceProvider.GetRequiredService<BaseDadosRepository>();
    var popularBancoBasePrefeitura = scope.ServiceProvider.GetRequiredService<PopularBancoBasePrefeitura>();

    // Chamar o m�todo para popular a base de dados no escopo correto
    popularBancoBasePrefeitura.MobiliarBaseDados(
        scope.ServiceProvider.GetRequiredService<AppDbContext>(),
        scope.ServiceProvider.GetRequiredService<BaseDados>(),
        scope.ServiceProvider.GetRequiredService<BaseDadosRepository>()
    );
}

app.Run();


