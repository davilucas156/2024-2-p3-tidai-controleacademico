using System.Text.Json.Serialization;
using ControleAcademico.Data.Context;
using ControleAcademico.Data.Repositories;
using ControleAcademico.Domain.Interfaces.Repositories;
using ControleAcademico.Domain.Interfaces.Services;
using ControleAcademico.Domain.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuring Context
builder.Services.AddDbContext<ControleAcademicoContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("Default"),
        new MySqlServerVersion(new Version(8, 0, 25)) // Substitua pela versão do MySQL que você está usando
    )
);

builder.Services.AddScoped<IgeralRepo, GeralRepo>();

builder.Services.AddScoped<ICursoRepo, CursoRepo>();
builder.Services.AddScoped<ICursoService, CursoService>();


// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
        c.RoutePrefix = string.Empty; // Define o Swagger na raiz do localhost
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
