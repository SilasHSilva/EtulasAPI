using EtulasAPI.Data;
using EtulasAPI.Interfaces;
using EtulasAPI.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Adicionando serviços à DI (injeção de dependências)
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.NumberHandling = JsonNumberHandling.AllowNamedFloatingPointLiterals;
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<HospitalDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("OracleDb"))
           .EnableSensitiveDataLogging()
           .LogTo(Console.WriteLine, LogLevel.Information));


// Serviços de aplicação (injeção de dependências)
builder.Services.AddScoped<IHospitalService, HospitalService>();
builder.Services.AddScoped<IPatientService, PatientService>();

var app = builder.Build();

// Configurações do pipeline de requisição
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
