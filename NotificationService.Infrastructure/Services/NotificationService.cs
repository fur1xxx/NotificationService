using NotificationService.Domain.Entities;
using NotificationService.Domain.IProvider;
using NotificationService.Domain.Services.Interfaces;

namespace NotificationService.Infrastructure.Services;

public class NotificationService : INotificationService
{
    private readonly IEnumerable<INotificationProvider> _notificationProviders;
    
    public NotificationService(IEnumerable<INotificationProvider> notificationProviders)
    {
        _notificationProviders = notificationProviders;
    }
    
    public async Task<bool> SendNotificationAsync(Notification notification)
    {
        foreach (INotificationProvider provider in _notificationProviders.Where(p => p.SupportsChannel(notification.Channel)))
        {
            try
            {
                if (await provider.SendAsync(notification))
                {
                    Console.WriteLine($"Notification sent via {provider.GetType().Name}");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to send notification via {provider.GetType().Name}: {ex.Message}");
            }
        }
        
        Console.WriteLine("All providers failed. Notification will be queued for retry.");
        return false;
    }
}