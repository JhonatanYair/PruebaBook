using ApiBookTest.Models;
using ApiBookTest.Repositories;
using ApiBookTest.Service;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

string ASPNETCORE_ENVIRONMENT = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
string connectionString;

if (ASPNETCORE_ENVIRONMENT == "Development")
{
    connectionString = builder.Configuration.GetConnectionString("cnApiBookTestLocal");
}
else
{
    connectionString = builder.Configuration.GetConnectionString("cnApiBookTestDocker");
}

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<BDBookTestContext>(options =>
    options.UseNpgsql(connectionString));
builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddScoped<IRepository<books>, Repository<books>>();
builder.Services.AddScoped<IRepository<authors>, Repository<authors>>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IBookService, BookService>();


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
