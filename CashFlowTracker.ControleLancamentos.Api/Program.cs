using CashFlowTracker.ControleLancamentos.Api.Configurations;
using CashFlowTracker.Domain.Services.Implementations.Base;
using CashFlowTracker.Domain.Services.Interfaces.Base;
using CashFlowTracker.Infrastructure.SqLite.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
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

// Migrate the database on startup (if necessary).
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.Migrate();
}

app.Run();