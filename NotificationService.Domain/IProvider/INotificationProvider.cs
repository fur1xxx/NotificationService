using NotificationService.Domain.Entities;
using NotificationService.Domain.Enums;

namespace NotificationService.Domain.IProvider;

public interface INotificationProvider
{
    bool SupportsChannel(NotificationChannel channel);
    Task<bool> SendAsync(Notification notification);
}