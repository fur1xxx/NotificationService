using System.Collections.Concurrent;
using NotificationService.Domain.Entities;
using NotificationService.Domain.IRetryQueue;

namespace NotificationService.Infrastructure.RetryQueue;

public class NotificationRetryQueue : INotificationRetryQueue
{
    private readonly ConcurrentQueue<Notification> _notificationQueue = new();

    public void AddToQueue(Notification notification)
    {
        _notificationQueue.Enqueue(notification);
    }

    public bool TryDequeue(out Notification notification)
    {
        return _notificationQueue.TryDequeue(out notification);
    }

    public int Count => _notificationQueue.Count;
}