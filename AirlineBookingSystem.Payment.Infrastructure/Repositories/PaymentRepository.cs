using System.Data;
using AirlineBookingSystem.Payment.Core.Repositories;
using Dapper;

namespace AirlineBookingSystem.Payment.Infrastructure.Repositories;

public class PaymentRepository(IDbConnection dbConnection) : IPaymentRepository
{
    public Task ProcessPaymentAsync(Core.Entities.Payment payment)
    {
        const string sql = @"INSERT INTO [dbo].[Payments] ([Id], [BookingId], [Amount], [PaymentDate]) VALUES (@Id, @BookingId, @Amount, @PaymentDate);";
        return dbConnection.ExecuteAsync(sql, payment);
    }

    public Task RefundPaymentAsync(Guid paymentId)
    {
        const string sql = $"DELETE FROM Payments WHERE Id = @Id";
        return dbConnection.ExecuteAsync(sql, new { Id = paymentId });
    }
}