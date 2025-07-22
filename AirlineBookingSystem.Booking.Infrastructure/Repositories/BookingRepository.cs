using AirlineBookingSystem.Booking.Core.Repositories;
using System.Data;
using Dapper;

namespace AirlineBookingSystem.Booking.Infrastructure.Repositories;

public class BookingRepository(IDbConnection dbConnection) : IBookingRepository
{
    public Task<Core.Entities.Booking?> GetByIdAsync(Guid id)
    {
       const string sql = $"SELECT * FROM Bookings WHERE Id = @Id";
         return dbConnection.QuerySingleOrDefaultAsync<Core.Entities.Booking>(sql, new { Id = id });
    }

    public Task<IEnumerable<Core.Entities.Booking>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(Core.Entities.Booking booking)
    {
       const string sql = @"INSERT INTO [AirlineBookingSystem].[dbo].[Bookings] ([Id], [FlightId], [PassengerName], [SeatNumber], [BookingDate]) 
            VALUES (@Id, @FlightId, @PassengerName, @SeatNumber, @BookingDate)";
        return dbConnection.ExecuteAsync(sql, booking);
    }
}