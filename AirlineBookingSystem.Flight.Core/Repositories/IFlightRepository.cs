namespace AirlineBookingSystem.Flight.Core.Repositories;

public interface IFlightRepository
{
    Task<Entities.Flight> GetByIdAsync(Guid id);
    Task<IEnumerable<Entities.Flight>> GetAllAsync();
    Task AddAsync(Entities.Flight booking);
    Task AddDelete(Guid id);
}