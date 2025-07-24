using MediatR;

namespace AirlineBookingSystem.Flight.Application.Queries;

public record GetByIdQuery(Guid Id): IRequest<Core.Entities.Flight?>;
