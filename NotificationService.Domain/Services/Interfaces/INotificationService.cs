using NotificationService.Domain.Entities;

namespace NotificationService.Domain.Services.Interfaces;

public interface INotificationService
{
    Task<bool> SendNotificationAsync(Notification notification);
}