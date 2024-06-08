using Microsoft.EntityFrameworkCore;
using Sistema_Venta_y_Renta_Peliculas.DAL.Entities;
using Sistema_Venta_y_Renta_Peliculas.Domain.Interfaces;
using Sistema_Venta_y_Renta_Peliculas.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Esta es la linea de código que se necesita para configurar la conexión a la BD
builder.Services.AddDbContext<DataBaseContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString
("DefaultConnection")));

//Contener de dependencias, sin esto genera error
builder.Services.AddTransient<IMovieService, MovieService>();
builder.Services.AddTransient<IBillService, BillService>();
builder.Services.AddTransient<IUserService, UserService>();
//builder.Services.AddScoped<IBillService, BillService>();
//builder.Services.AddScoped<IBillService, BillService>();


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

app.UseIdentity();

app.Run();
