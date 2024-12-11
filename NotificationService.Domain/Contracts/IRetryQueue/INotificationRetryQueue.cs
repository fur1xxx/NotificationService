using NotificationService.Domain.Entities;

namespace NotificationService.Domain.IRetryQueue;

public interface INotificationRetryQueue
{
    void AddToQueue(Notification notification);
    bool TryDequeue(out Notification notification);
    int Count { get; }
}