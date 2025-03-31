using Microsoft.EntityFrameworkCore;
using Projeto_Geo.Domain;
using Projeto_Geo.Repository;
using Projeto_Geo.Repository.Consultas;
using Projeto_Geo.Servicos;

var builder = WebApplication.CreateBuilder(args);

// Adicionar serviços ao contêiner

builder.Services.AddControllers();
// Saiba mais sobre a configuração do Swagger/OpenAPI em https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//-- serviços

// Conexão com o banco de dados
var connectionstring = builder.Configuration.GetConnectionString("geoprefeitura");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionstring, ServerVersion.AutoDetect(connectionstring)));

// Registrar os serviços necessários
builder.Services.AddScoped<BaseDadosRepository>();
builder.Services.AddScoped<PopularBancoBasePrefeitura>();
builder.Services.AddScoped<BaseDados>();
builder.Services.AddScoped<ValidadorXLSX>();


var app = builder.Build();

// Configurar o pipeline de requisição HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Criar um escopo para resolver o AppDbContext e os outros serviços corretamente
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    var baseDadosRepository = scope.ServiceProvider.GetRequiredService<BaseDadosRepository>();
    var popularBancoBasePrefeitura = scope.ServiceProvider.GetRequiredService<PopularBancoBasePrefeitura>();

    // Chamar o método para popular a base de dados no escopo correto
    popularBancoBasePrefeitura.MobiliarBaseDados(
        scope.ServiceProvider.GetRequiredService<AppDbContext>(),
        scope.ServiceProvider.GetRequiredService<BaseDados>(),
        scope.ServiceProvider.GetRequiredService<BaseDadosRepository>()
    );
}

app.Run();


