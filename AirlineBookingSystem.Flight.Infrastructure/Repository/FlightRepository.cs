using System.Data;
using AirlineBookingSystem.Flight.Core.Repositories;
using Dapper;

namespace AirlineBookingSystem.Flight.Infrastructure.Repository;

public class FlightRepository(IDbConnection dbConnection) : IFlightRepository
{
    public Task<Core.Entities.Flight?> GetByIdAsync(Guid id)
    {
        const string sql = $"SELECT * FROM Flights WHERE Id = @Id";
        return dbConnection.QuerySingleOrDefaultAsync<Core.Entities.Flight>(sql, new { Id = id });
    }

    public Task<IEnumerable<Core.Entities.Flight>> GetAllAsync()
    {
        const string sql = $"SELECT * FROM Flights";
        return dbConnection.QueryAsync<Core.Entities.Flight>(sql);
    }

    public Task AddAsync(Core.Entities.Flight booking)
    {
        const string sql = @"INSERT INTO [dbo].[Flights] ([Id], [FlightNumber], [Origin], [Destination], [DepartureTime], [ArrivalTime]) 
                             VALUES (@Id, @FlightNumber, @Origin, @Destination, @DepartureTime, @ArrivalTime)";
        return dbConnection.ExecuteAsync(sql, booking);
    }

    public Task AddDelete(Guid id)
    {
        const string sql = $"DELETE FROM Flights WHERE Id = @Id";
        return dbConnection.ExecuteAsync(sql, new { Id = id });
    }
}