using System.Data;
using System.Reflection;
using AirlineBookingSystem.Booking.Application.Handlers;
using AirlineBookingSystem.Booking.Application.Queries;
using AirlineBookingSystem.Booking.Core.Repositories;
using AirlineBookingSystem.Booking.Infrastructure.Repositories;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IDbConnection>(x => new SqlConnection(builder.Configuration.GetConnectionString("DefaultConnection")));

//Register RabbitMq
var assemblies = new Assembly[]
{
    Assembly.GetExecutingAssembly(),
    typeof(GetBookingByIdQueryHandler).Assembly,
    typeof(CreateBookingCommandHandler).Assembly
};
builder.Services.AddMediatR(x=>x.RegisterServicesFromAssemblies(assemblies));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();