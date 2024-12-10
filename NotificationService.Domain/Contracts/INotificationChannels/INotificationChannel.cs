using NotificationService.Domain.Entities;
using NotificationService.Domain.Enums;

namespace NotificationService.Domain.Contracts.INotificationChannels;

public interface INotificationChannel
{
    NotificationChannelType ChannelType { get; }
    bool IsEnabled { get; }
    Task<bool> SendNotificationAsync(Notification notification);
}