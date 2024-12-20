using API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Register the DataContext with the container
builder.Services.AddDbContext<DataContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddCors();
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCors(x =>x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200","http://localhost:4200"));

app.MapControllers();

app.Run();