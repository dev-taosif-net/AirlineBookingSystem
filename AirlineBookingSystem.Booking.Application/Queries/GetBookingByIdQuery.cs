using MediatR;

namespace AirlineBookingSystem.Booking.Application.Queries;

public record GetBookingByIdQuery(Guid Id) : IRequest<Core.Entities.Booking?>;
