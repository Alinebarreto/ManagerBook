using ManagerBook.API.Configuration;
using ManagerBook.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add database context 
var connectionString = builder.Configuration.GetConnectionString("ManagerBookCs");
builder.Services.AddDbContext<ManagerBookDbContext>(options => options.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.RepositoriesSetup();
builder.Services.ServicesSetup();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
