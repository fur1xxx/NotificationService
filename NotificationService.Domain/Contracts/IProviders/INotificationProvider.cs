using NotificationService.Domain.Entities;
using NotificationService.Domain.Enums;

namespace NotificationService.Domain.Contracts.IProviders;

public interface INotificationProvider
{
    bool SupportsChannel(NotificationChannelType channelType);
    Task<bool> SendAsync(Notification notification);
}