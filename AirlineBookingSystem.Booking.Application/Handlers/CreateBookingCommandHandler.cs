using AirlineBookingSystem.Booking.Application.Commands;
using AirlineBookingSystem.Booking.Core.Repositories;
using MediatR;

namespace AirlineBookingSystem.Booking.Application.Handlers;

public class CreateBookingCommandHandler(IBookingRepository repository) : IRequestHandler<CreateBookingCommand, Guid>
{
    public async Task<Guid> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
    {
        var booking = new Core.Entities.Booking()
        {
            Id = Guid.NewGuid(),
            FlightId = request.FlightId,
            PassengerName = request.PassengerName,
            SeatNumber = request.SeatNumber,
            BookingDate = DateTime.UtcNow
        };

        await repository.AddAsync(booking);
        return await Task.FromResult(booking.Id);
    }
}