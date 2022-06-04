using GestaoDeTimes.Context;
using GTDV.Application.Interfaces;
using GTDV.Application.Servicos;
using GTDV.Domain.Repositorio;
using GTDV.Infra.Repositorio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<GestaoTimesContexto>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("GESTAO_TIMES")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IJogadorService, JogadorService>();
builder.Services.AddTransient<IJogadorRepository, JogadorRepository>();

var app = builder.Build();

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
