using System.Data;
using AirlineBookingSystem.Notification.Core.Repositories;
using Dapper;

namespace AirlineBookingSystem.Notification.Infrastructure.Repositories;

public class NotificationRepository(IDbConnection dbConnection) : INotificationRepository
{
    public Task LogNotificationAsync(Core.Entities.Notification notification)
    {
        const string sql = @"INSERT INTO [AirlineBookingSystem].[dbo].[Notifications] ([Id], [Recipient], [Message], [Type], [SentAt]) VALUES (@Id, @Recipient, @Message, @Type, @SentAt)";
        return dbConnection.ExecuteAsync(sql, notification);
    }
}