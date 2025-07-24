using MediatR;

namespace AirlineBookingSystem.Flight.Application.Queries;

public record GetAllQuery : IRequest<IEnumerable<Core.Entities.Flight>>;
