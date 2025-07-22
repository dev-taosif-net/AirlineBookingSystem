namespace AirlineBookingSystem.Booking.Core.Repositories;

public interface IBookingRepository
{
    Task<Entities.Booking> GetByIdAsync(Guid id);
    Task<IEnumerable<Entities.Booking>> GetAllAsync();
    Task AddAsync(Entities.Booking booking);
}