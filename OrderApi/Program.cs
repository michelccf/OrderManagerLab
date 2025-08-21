using Microsoft.EntityFrameworkCore;
using OrderApi.Interfaces.Repositories;
using OrderApi.Interfaces.Services;
using OrderApi.Repositories;
using OrderApi.Services;
using Resouces.Extensions;
using Resources.DbContextService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
string connectionString = builder.Configuration.GetSection("Postgree:ConnectionString").Value;
builder.Services.AddDbContext<DbContextService>(options => options.UseNpgsql(connectionString));
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
