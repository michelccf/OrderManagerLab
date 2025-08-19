using Microsoft.EntityFrameworkCore;
using Resources.DbContextService;
using UserApi.Interfaces.Repositories;
using UserApi.Interfaces.Services;
using UserApi.Repositories;
using UserApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

string connectionString = builder.Configuration.GetSection("Postgree:ConnectionString").Value;

builder.Services.AddDbContext<DbContextService>(options => options.UseNpgsql(connectionString));

builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IUserRepository, UserRepository>();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
