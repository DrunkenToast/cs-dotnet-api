using cs_dotnet_api.Contexts;
using cs_dotnet_api.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
String? _connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];
System.Console.WriteLine(_connectionString);
if (_connectionString == null) {
    throw new ArgumentException("No connection string");
}

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRepo, MySqlRepo>();
builder.Services.AddDbContext<ItemContext>(opt => opt.UseMySql(_connectionString, ServerVersion.AutoDetect(_connectionString)));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();
// app.UseAuthorization();

app.MapControllers();

app.Run();
