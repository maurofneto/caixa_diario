using CashFlowTracker.ConsolidadoDiario.Api.Configurations;
using CashFlowTracker.Infrastructure.SqLite.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add configuration to read from appSettings.json.
var configuration = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appSettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appSettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .Build();

// Add database context to the container with the Connection String from appSettings.json.
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite(configuration.GetConnectionString("DefaultConnection"), opt =>
    {
        opt.MigrationsAssembly("CashFlowTracker.ControleLancamentos.Api");
    });
});

builder.Services.RegisterServices(builder.Configuration);
builder.Services.RegisterRepositories(builder.Configuration);

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
