using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using ProjetoSOLID.Application.Mappings;
using ProjetoSOLID.Application.Services;
using ProjetoSOLID.Domain.Interfaces;
using ProjetoSOLID.Infrastructure.Data;
using ProjetoSOLID.Infrastructure.Repositories;
using ProjetoSOLID.Infrastructure.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Adiciona o AutoMapper (mapeamento entre DTOs e entidades)
builder.Services.AddAutoMapper(typeof(DomainToDtoProfile), typeof(DtoToDomainProfile));

// Controllers
builder.Services.AddControllers();

// Configuração do SQL Server
builder.Services.AddDbContext<ProjetoDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Injeção de dependências
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IClienteService, ClienteService>();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Projeto SOLID API", Version = "v1" });
});

var app = builder.Build();

// Ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
