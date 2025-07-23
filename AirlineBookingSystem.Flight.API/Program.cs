using System.Data;
using AirlineBookingSystem.Flight.Core.Repositories;
using AirlineBookingSystem.Flight.Infrastructure.Repository;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IFlightRepository, FlightRepository>();
builder.Services.AddScoped<IDbConnection>(x => new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();