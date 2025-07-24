using AirlineBookingSystem.Booking.Application.Queries;
using AirlineBookingSystem.Booking.Core.Repositories;
using MediatR;

namespace AirlineBookingSystem.Booking.Application.Handlers;

public class GetBookingByIdQueryHandler(IBookingRepository repository) : IRequestHandler<GetBookingByIdQuery, Core.Entities.Booking>
{
    public async Task<Core.Entities.Booking> Handle(GetBookingByIdQuery request, CancellationToken cancellationToken)
    {
        return await repository.GetByIdAsync(request.Id);
    }
}